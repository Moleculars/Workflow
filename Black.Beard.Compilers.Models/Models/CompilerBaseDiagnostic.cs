namespace Bb.Compilers.Models
{
    public class CompilerBaseDiagnostic
    {

        public CompilerBaseDiagnostic()
        {
        }

        public int LineNumber { get; internal set; }

        public int LinePosition { get; internal set; }

        public string Name { get; internal set; }

        public string Message { get; internal set; }

    }

}