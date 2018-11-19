using System.Text;

namespace Bb.Core.Documents
{
    public class CheckResult
    {

        public string Document { get; set; }

        public string Message { get; set; }

        public int LineNumber { get; set; }

        public int LinePosition { get; set; }

        public string Name { get; set; }

        public SeverityEnum Severity { get; set; }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder(100);

            sb.Append(Severity.ToString());
            sb.Append(" ");

            if (!string.IsNullOrEmpty(Name))
                sb.Append($"property {Name} ");

            sb.Append($"at (line : {LineNumber}, position : {LinePosition}) in {Document} ");
            sb.Append(Message);

            return sb.ToString();

        }

    }

    public enum SeverityEnum
    {

        Undefined,

        Verbose,
        Information,
        Warning,
        Error,

    }

}
