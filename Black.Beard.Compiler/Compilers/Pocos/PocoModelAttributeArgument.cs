using System.Text;

namespace Bb.Compilers.Pocos
{
    public class PocoModelAttributeArgument
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public bool IsString { get; set; }

        internal void Crc(StringBuilder sb)
        {

            var v = Value;
            if (IsString)
                v = $"\"{v}\"";

            if (string.IsNullOrEmpty(Name))
                sb.Append($"{v}");
            else
                sb.Append($"{Name} = {v}");

        }
    }

}
