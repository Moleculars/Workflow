using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Bb.Logs
{

    internal class AssemblyLogger
    {

        internal static void Initialize()
        {

            AssemblyLogger._instance = new AssemblyLogger();

        }

        private AssemblyLogger()
        {
            _referentiels = new HashSet<string>();
            _lock = new object();
        }

        public static AssemblyLogger Instance
        {
            get
            {
                return _instance ?? throw new NullReferenceException(nameof(AssemblyLogger));
            }
        }


        public void GetAssemblies(Assembly assembly, Stack<StringBuilder> assembliesResult)
        {

            if (Ensure(assembly, out StringBuilder sb))
                assembliesResult.Push(sb);

            AssemblyName[] assemblies = assembly.GetReferencedAssemblies();

            foreach (AssemblyName ass in assemblies)
                if (!ass.Name.StartsWith("System."))
                    try
                    {
                        var ass2 = Assembly.Load(ass);
                        if (Ensure(ass2, out sb))
                            assembliesResult.Push(sb);
                    }
                    catch (Exception ex)
                    {
                        // ???
                        string msg = ex.Message;
                    }

        }

        private bool Ensure(Assembly assembly, out StringBuilder result)
        {

            result = null;

            FileInfo file = new FileInfo(assembly.Location);
            string location = $"{file.Name};";
            lock (_lock)
                if (_referentiels.Add(location))
                {

                    using (var stream = file.OpenRead())
                    {
                        byte[] array = new byte[file.Length];
                        stream.Read(array, 0, array.Length);
                        result = new StringBuilder(location + Convert.ToBase64String(array, Base64FormattingOptions.None));
                    }

                    return true;

                }

            return false;

        }

        private volatile object _lock;
        private static AssemblyLogger _instance;
        private HashSet<string> _referentiels;

    }

}