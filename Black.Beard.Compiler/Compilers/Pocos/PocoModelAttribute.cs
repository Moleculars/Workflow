using System;
using System.Text;

namespace Bb.Compilers.Pocos
{
    public class PocoModelAttribute
    {


        public PocoModelAttribute(string name, params PocoModelAttributeArgument[] arguments) : this(arguments)
        {
            this.Name = name;
        }

        public PocoModelAttribute(params PocoModelAttributeArgument[] arguments)
        {
            this.Arguments = new PocoModelAttributeArguments();
            if (arguments != null)
                this.Arguments.AddRange(arguments);
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
