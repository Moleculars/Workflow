using Bb.Compilers.Pocos;
using Bb.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Workflow.Configurations.IncomingMessages
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
        }

        public void Add(PocoModel model)
        {

            if (_items.ContainsKey(model.Name))
                throw new Exception($"a model named {model.Name} allready exist.");

            _items.Add(model.Name, model);

        }

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
        public HashSet<string> Usings { get; }
        public IEnumerable<PocoModel> Pocos => _items.Values;

        internal PocoModel Get(string type)
        {
            _items.TryGetValue(type, out PocoModel model);
            return model;
        }

        private Dictionary<string, PocoModel> _items = new Dictionary<string, PocoModel>();

        public AssemblyResult Generate(PocoCodeGenerator codeGenerator, string outPath)
        {
            return codeGenerator.Generate(this, outPath);
        }

    }

}
