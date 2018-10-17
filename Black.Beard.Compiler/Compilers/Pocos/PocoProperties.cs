using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Workflow.Configurations.IncomingMessages
{

    public class PocoProperties : List<PocoProperty>
    {


        internal void Crc (StringBuilder sb)
        {
            foreach (var item in this.OrderBy(c => c.Name))
                item.Crc(sb);
        }

    }

}
