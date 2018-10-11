using System;
using System.Collections.Generic;

namespace Bb.ComponentModel
{

    // Permet d'initializer proprement le découvreur de type
    public class TypeReferential
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeReferential"/> class.
        /// </summary>
        /// <param name="paths">The paths.</param>
        private TypeReferential(params string[] paths)
        {
            this.discover = new TypeDiscovery(paths);
        }


        /// <summary>
        /// Initializes <see cref="global::ThisAssembly:TypeReferential"/>: with the specified paths for discover the types.
        /// </summary>
        /// <param name="paths">The paths.</param>
        /// <exception cref="System.Exception">Type discover allready initialized</exception>
        public static void Initialize(params string[] paths)
        {

            if (TypeReferential._instance == null)
                lock(_lock)
                    if (TypeReferential._instance == null)

            TypeReferential._instance = new TypeReferential(paths);

        }

        public static void Clear()
        {

            if (TypeReferential._instance != null)
                lock (_lock)
                    if (TypeReferential._instance != null)
                        TypeReferential._instance = null;

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

        /// <summary>
        /// Gets the instance. (note is not a singleton but unit of work)
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static TypeReferential Instance
        {
            get
            {
                return TypeReferential._instance;
            }
        }

        private readonly TypeDiscovery discover;
        private static TypeReferential _instance;
        private static object _lock = new object();

    }


}
