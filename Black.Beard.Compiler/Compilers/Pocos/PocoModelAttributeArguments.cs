using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Workflow.Configurations.IncomingMessages
{
    public class PocoModelAttributeArguments : List<PocoModelAttributeArgument>
    {
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
