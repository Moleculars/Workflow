using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Compilers.Pocos
{
    public class PocoModelAttributeArguments : List<PocoModelAttributeArgument>
    {

        public PocoModelAttributeArguments() : base()
        {

        }

        public PocoModelAttributeArguments(IEnumerable<PocoModelAttributeArgument> collection) : base(collection)
        {
        }

        internal void Crc(StringBuilder sb)
        {
            string comma = string.Empty;
            foreach (var item in this)
            {
                sb.Append(comma);
                item.Crc(sb);
                comma = ", ";
            }
        }
    }

}
