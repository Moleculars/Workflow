using System;
using System.Text;

namespace Bb.Workflow.Configurations.IncomingMessages
{
    public class PocoModelAttribute
    {

        public PocoModelAttribute()
        {
            this.Arguments = new PocoModelAttributeArguments();
        }

        public string Name { get; set; }

        public PocoModelAttributeArguments Arguments { get; set; }

        internal void Crc(StringBuilder sb)
        {

            sb.Append(string.Concat("      ", Name , "("));
            Arguments.Crc(sb);
            sb.Append(")");

        }
    }

}
