using System.Linq;
using System.Text;

namespace Bb.Compilers.Pocos
{

    [System.Diagnostics.DebuggerDisplay("class {Name}")]
    public class PocoModel
    {

        public PocoModel(params PocoProperty[] properties)
        {
            Properties = new PocoProperties();
            Interfaces = new PocoInterfaces();
            Attributes = new PocoModelAttributes();
            if (properties != null)
                Properties.AddRange(properties);
        }

        public string Name { get; set; }

        public string BaseName { get; set; }

        public string Description { get; set; }

        public PocoInterfaces Interfaces { get; set; }

        public PocoModelAttributes Attributes { get; set; }

        public PocoProperties Properties { get; set; }

        internal void Crc(StringBuilder sb)
        {
            sb.AppendLine(string.Concat(Name, ":", string.IsNullOrEmpty(BaseName) ? "object" : "BaseName", ":", Description, ":"));
            sb.AppendLine(string.Join(", ", Interfaces.OrderBy(c => c)));
            Attributes.Crc(sb);
            Properties.Crc(sb);
            sb.AppendLine("");
        }
    }

}
