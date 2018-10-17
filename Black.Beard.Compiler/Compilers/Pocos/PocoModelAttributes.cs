using System.Collections.Generic;
using System.Text;

namespace Bb.Workflow.Configurations.IncomingMessages
{
    public class PocoModelAttributes : List<PocoModelAttribute>
    {

        internal void Crc(StringBuilder sb)
        {
            foreach (var item in this)
                item.Crc(sb);
        }

    }

}
