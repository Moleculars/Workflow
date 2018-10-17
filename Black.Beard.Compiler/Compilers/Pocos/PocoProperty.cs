using Bb.Core.Helpers;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Bb.Workflow.Configurations.IncomingMessages
{
    public class PocoProperty
    {

        public PocoProperty()
        {
            Attributes = new PocoModelAttributes();

        }

        public string Name { get; set; }

        public bool IsArray { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }
        public PocoModelAttributes Attributes { get; private set; }

        internal void Crc(StringBuilder sb)
        {
            sb.Append(string.Concat("   ", Name, ":", Type, ":",Description, ":", IsArray ? "array" : "no"));
            Attributes.Crc(sb);
        }

        
    }

}
