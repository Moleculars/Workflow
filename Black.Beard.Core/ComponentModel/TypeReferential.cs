using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bb.ComponentModel
{

    // Permet d'initializer proprement le découvreur de type
    public class TypeReferential
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeReferential"/> class.
        /// </summary>
        /// <param name="paths">The paths.</param>
        public TypeReferential(params string[] paths)
        {
            this.discover = new TypeDiscovery(paths);
        }

        /// <summary>
        /// Adds the specified path for type reseach.
        /// </summary>
        /// <param name="path">The path.</param>
        public void AddPath(string path)
        {
            this.discover.AddDirectory(new System.IO.DirectoryInfo(path));
        }

        public Type ResolveByName(string targetType)
        {
            return this.discover.ResolveByName(targetType);
        }

        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException">type</exception>
        public List<Type> GetTypesWithAttributes(Type type)
        {

            if (type == null)
                throw new NullReferenceException(nameof(type));

            return this.discover.ResolveWithAttribute(type);

        }

        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="baseType">The base type.</param>
        /// <param name="attributeType">The type.</param>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException">type</exception>
        public List<Type> GetTypesWithAttributes(Type baseType, Type attributeType)
        {

            if (baseType == null)
                throw new NullReferenceException(nameof(baseType));

            if (attributeType == null)
                throw new NullReferenceException(nameof(attributeType));

            return this.discover.ResolveWithAttribute(baseType, attributeType);

        }

        public Assembly AddAssemblyFile(string path)
        {
            return this.discover.LoadAssembly(path);
        }

        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException">type</exception>
        public List<Type> GetTypes(Type type)
        {

            if (type == null)
                throw new NullReferenceException(nameof(type));

            return this.discover.Resolve(type);
        }

        /// <summary>
        /// Return a list of type that match with the specified filter
        /// </summary>
        /// <param name="fnc">The FNC.</param>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException">fnc</exception>
        public List<Type> GetTypes(Func<Type, bool> fnc)
        {

            if (fnc == null)
                throw new NullReferenceException(nameof(fnc));

            return this.discover.Resolve(fnc);
        }

        private readonly TypeDiscovery discover;
        private static object _lock = new object();

    }


}
