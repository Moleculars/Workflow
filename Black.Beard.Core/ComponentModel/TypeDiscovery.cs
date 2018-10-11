using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel
{

    public class TypeDiscovery
    {

        private static volatile object _lock = new object();

        /// <summary>
        ///     The on register exception
        /// </summary>
        public static Action<Exception> OnRegisterException = e => { };

        /// <summary>
        ///     The on registration event
        /// </summary>
        public static Action<string> OnRegistrationEvent = e => Debug.WriteLine(e);

        /// <summary>
        ///     function  return the list of loaded assemblies
        /// </summary>
        private readonly Func<IEnumerable<Assembly>> Assemblies;

        private readonly DirectoryInfo[] paths;

        /// <summary>
        ///     define a filter for filter the assemblies to use in the register
        /// </summary>
        public Func<Assembly, bool> FilterAssembly;

        /// <summary>
        ///     The filter fileinfo
        /// </summary>
        public Func<FileInfo, bool> FilterFilename;

        public TypeDiscovery(params string[] pluginsPaths)
        {

            if (pluginsPaths == null)
                pluginsPaths = new string[] { };

            ExcludedAssemblies = new List<string>();
            FilterAssembly = c => true;
            FilterFilename = c => true;
            Assemblies = () => AppDomain.CurrentDomain.GetAssemblies()
                .Where(c => !ExcludedAssemblies.Contains(c.GetName().Name)
                ).ToList();
            //OnRegisterException = e => Logger.Error(e);
            HideAssemblyLoadException = true;

            var h = new HashSet<string>();
            var dir = FolderBinResolver.IsWebApplication()
                ? FolderBinResolver.GetWebBinPath().ToList()
                : FolderBinResolver.GetConsoleBinPath().ToList();

            foreach (var _path in pluginsPaths)
                if (!string.IsNullOrEmpty(_path))
                    if (h.Add(_path))
                        dir.Add(new DirectoryInfo(_path));

            paths = dir.Where(c => c.Exists).ToArray();

            //foreach (var item in paths)
            //    Trace.WriteLine($" the type discover is initialized with path '{item.FullName}'");

        }

        /// <summary>
        ///     The exclude assemblies
        /// </summary>
        public static List<string> ExcludedAssemblies { get; private set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [hide assembly load exception].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [hide assembly load exception]; otherwise, <c>false</c>.
        /// </value>
        public static bool HideAssemblyLoadException { get; set; }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var n = new AssemblyName(args.Name);

            foreach (var baseDirectory in paths)
            {
                var fileInfo = baseDirectory.GetFiles(n.Name + ".dll", SearchOption.AllDirectories).FirstOrDefault();
                if (fileInfo != null)
                {
                    var assembly = Assembly.LoadFile(fileInfo.FullName);
                    return assembly;
                }
                fileInfo = baseDirectory.GetFiles(n.Name + ".exe").FirstOrDefault();
                if (fileInfo != null)
                {
                    var assembly = Assembly.LoadFile(fileInfo.FullName);
                    return assembly;
                }
            }

            var str =
                $"the assembly '{args.Name}' can't be resolved in the folder '{AppDomain.CurrentDomain.BaseDirectory}'";

            Console.Write(str);

            return null;
        }

        /// <summary>
        ///     Return a list of type that match with the specified filter
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public List<Type> Resolve(Func<Type, bool> typeFilter)
        {
            LoadAssemblies();
            var result = new List<Type>();
            var assemblies = Assemblies().ToArray();
            result.AddRange(Collect(typeFilter, assemblies));
            return result;
        }

        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public List<Type> ResolveWithAttribute(Type baseType, Type typeFilter)
        {
            LoadAssemblies();
            var result = new List<Type>();
            var assemblies = Assemblies().ToArray();
            result.AddRange(Collect(type =>
            {
                return baseType.IsAssignableFrom(type) && Attribute.GetCustomAttributes(type, typeFilter).Any();
            }, assemblies));

            return result;
        }

        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public List<Type> ResolveWithAttribute(Type typeFilter)
        {
            LoadAssemblies();
            var result = new List<Type>();
            var assemblies = Assemblies().ToArray();
            result.AddRange(Collect(type =>
            {
                return Attribute.GetCustomAttributes(type, typeFilter).Any();
            }, assemblies));

            return result;
        }

        /// <summary>
        ///     return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public List<Type> Resolve(Type typeFilter)
        {
            LoadAssemblies();
            var result = new List<Type>();
            var assemblies = Assemblies().ToArray();
            result.AddRange(Collect(type => typeFilter.IsAssignableFrom(type) && type != typeFilter, assemblies));

            return result;
        }


        /// <summary>
        ///     Load in memory all the assemblies from the directory bin.
        /// </summary>
        private void LoadAssemblies()
        {
            foreach (var path in paths)
                LoadAssembliesFrom(path);
        }

        /// <summary>
        ///     Load in memory all the assemblies from the specified with directory.
        /// </summary>
        /// <returns></returns>
        private void LoadAssembliesFrom(DirectoryInfo dir)
        {
            var _h = new HashSet<string>();

            foreach (var item in Assemblies())
            {
                var name = item.GetName().Name;
                _h.Add(name);
                //Trace.WriteLine($"the type resolver will search in assembly {name}");
            }

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            try
            {
                var files = dir.GetFiles("*.dll").Where(c => FilterFilename(c));
                foreach (var file in files)
                {
                    var n = Path.GetFileNameWithoutExtension(file.Name);
                    if (_h.Add(n))
                    {
                        Assembly ass = null;
                        try
                        {
                            //Debug.WriteLine("Loading " + file.FullName);
                            ass = Assembly.LoadFile(file.FullName);
                            //Trace.WriteLine($"the type resolver will search in assembly {ass.GetName().Name}");

                        }
                        catch (Exception e)
                        {
                            OnRegisterException(e);
                            Trace.TraceError(e.ToString());
                        }
                    }
                }
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }
        }

        /// <summary>
        ///     Registers the specified assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        private List<Type> Collect(Func<Type, bool> typeFilter, params Assembly[] assemblies)
        {
            var result = new List<Type>();

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            try
            {
                foreach (var item in assemblies)
                    result.AddRange(Resolve(item, typeFilter));
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }

            return result;
        }

        /// <summary>
        ///     Register all exported type in the specified assembly
        /// </summary>
        /// <param name="ass"></param>
        private List<Type> Resolve(Assembly ass, Func<Type, bool> typeFilter)
        {
            var result = new List<Type>();

            if (ass != null && (FilterAssembly == null || FilterAssembly(ass)))
            {
                var n = ass.GetName();
                try
                {
                    result.AddRange(RegisterIoc(ass, typeFilter));
                    //Debug.WriteLine($"assembly {ass.GetName().Name} analyzed");
                }
                catch (Exception e)
                {
                    OnRegisterException(e);
                    Trace.TraceError(e.ToString());
                }
            }

            return result;
        }

        private static List<Type> RegisterIoc(Assembly assembly, Func<Type, bool> typeFilter)
        {
            var types = new Type[0];

            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e) // TypeLoadException e1
            {
                OnRegisterException(e);
                types = e.Types;
            }

            var _r = types.Where(type =>
           {
               var result = (!type.IsAbstract && !type.IsSealed || type.IsAbstract && type.IsSealed)
                                          && !type.IsInterface && !type.IsGenericTypeDefinition;

               return result;

           }).ToList();

            return _r.Where(typeFilter).ToList();

        }
    }
}