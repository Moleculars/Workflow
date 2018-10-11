using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Logs
{

    public class ExceptionDescriptor
    {

        public ExceptionDescriptor()
        {
            this.Stack = new List<CodeDescriptor>();
        }

        public string Message { get; internal set; }

        public ExceptionDescriptor Inner { get; internal set; }

        public List<CodeDescriptor> Stack { get; set; }

        public void Serialize(StringBuilder sb)
        {
            
            sb.Append("{");

            sb.Append($"{quote}M{quote}:{quote}{Message}{quote},");

            if (Inner != null)
            {
                sb.Append($"{quote}I{quote}:");
                Inner.Serialize(sb);
                sb.Append(",");
            }

            sb.Append($"{quote}S{quote}:[");
            string comma = string.Empty;

            Dictionary<string, int> _dic = new Dictionary<string, int>();

            foreach (CodeDescriptor code in Stack)
            {
                sb.Append(comma);
                code.Serialize(sb, _dic);
                comma = ", ";
            }

            sb.Append($"], ");

            sb.Append($"{quote}D{quote}:[");
            comma = string.Empty;

            foreach (var code in _dic)
            {
                sb.Append($"{comma}{{ {quote}K{quote}:{quote}{code.Value}{quote},{quote}V{quote}:{quote}{code.Key}{quote}}}");
                comma = ", ";
            }

            sb.Append($"]");


            sb.Append("}");

        }

        private const string quote = @"""";

    }

}