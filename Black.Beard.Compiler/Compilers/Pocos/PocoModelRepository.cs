using Bb.Compilers.Pocos;
using Bb.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bb.Compilers.Pocos
{

    /// <summary>
    /// List incomings message models 
    /// </summary>
    public class PocoModelRepository
    {

        public PocoModelRepository(string assemblyName)
        {
            AssemblyName = assemblyName;
            Usings = new HashSet<string>();
            References = new HashSet<Assembly>();
        }

        public void Add(PocoModel model)
        {

            if (_items.ContainsKey(model.Name))
                throw new Exception($"a model named {model.Name} allready exist.");

            _items.Add(model.Name, model);

        }

        /// <summary>
        /// Gets the filename of the new assembly.
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public string Filename => $"{AssemblyName}_{Crc().ToString()}";

        internal uint Crc()
        {

            StringBuilder sb = new StringBuilder();

            foreach (var item in _items)
            {
                sb.AppendLine("Type : ");
                item.Value.Crc(sb);
                sb.AppendLine("");
            }

            uint crc = Crc32.Calculate(sb);

            return crc;

        }

        public string AssemblyName { get; }

        /// <summary>
        /// Gets the usings list.
        /// </summary>
        /// <value>
        /// The usings.
        /// </value>
        public HashSet<string> Usings { get; }

        public HashSet<Assembly> References { get; }

        /// <summary>
        /// Adds the namespaces in the usings and assemblies in the references.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public PocoModelRepository AddUsings(params Type[] types)
        {
            foreach (var item in types)
            {
                Usings.Add(item.Namespace);
                this.References.Add(item.Assembly);
            }
            return this;

        }

        /// <summary>
        /// Adds the specified namespaces in the usings.
        /// </summary>
        /// <param name="namespaces">The namespaces.</param>
        /// <returns></returns>
        public PocoModelRepository AddUsings(params string[] namespaces)
        {
            foreach (var @namespace in namespaces)
                Usings.Add(@namespace);
            return this;
        }

        /// <summary>
        /// Gets the poco's list.
        /// </summary>
        /// <value>
        /// The pocos.
        /// </value>
        public IEnumerable<PocoModel> Pocos => _items.Values;

        /// <summary>
        /// Gets poco by the specified name.
        /// </summary>
        /// <param name="typeName">The type.</param>
        /// <returns></returns>
        public PocoModel Get(string typeName)
        {
            _items.TryGetValue(typeName, out PocoModel model);
            return model;
        }

        private Dictionary<string, PocoModel> _items = new Dictionary<string, PocoModel>();

        public AssemblyResult Generate(string outPath)
        {
            PocoCodeGenerator codeGenerator = new PocoCodeGenerator(this.References);
            return codeGenerator.Generate(this, outPath);
        }

    }

}
