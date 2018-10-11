using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Bb.Logs
{

    public class CodeDescriptor
    {
        
        public CodeDescriptor()
        {

        }

        public CodeDescriptor(int offset, System.Reflection.MethodBase method)
        {
            Offset = offset;
            this.DeclaringType = method.DeclaringType.FullName;
            this.Method = method.ToString();
            this.Assembly = method.DeclaringType.Assembly.FullName;
        }

        public int Offset { get; }

        public string DeclaringType { get; }

        public string Method { get; }

        public string Assembly { get; }

        public void Serialize(StringBuilder sb, Dictionary<string, int> _dic)
        {

            sb.Append("{");

            if (!_dic.TryGetValue(Assembly, out int value))
                _dic.Add(Assembly, (value = _dic.Count));
            sb.Append($"{quote}A{quote}:{quote}{value}{quote},");

            if (!_dic.TryGetValue(DeclaringType, out value))
                _dic.Add(DeclaringType, (value = _dic.Count));
            sb.Append($"{quote}D{quote}:{quote}{value}{quote},");

            if (!_dic.TryGetValue(Method, out value))
                _dic.Add(Method, (value = _dic.Count));
            sb.Append($"{quote}M{quote}:{quote}{value}{quote},");

            sb.Append($"{quote}O{quote}:{quote}{Offset}{quote}");

            sb.Append("}");
            
        }

        private const string quote = @"""";

    }

}
