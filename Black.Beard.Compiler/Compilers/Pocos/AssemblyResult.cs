using System.Collections.Generic;
using System.Reflection;

namespace Bb.Compilers.Pocos
{
    public class AssemblyResult
    {

        public AssemblyResult()
        {
            this.Disgnostics = new List<string>();
        }

        public string AssemblyName { get; internal set; }

        public string CodeFile { get; internal set; }

        public string AssemblyFile { get; internal set; }

        public string AssemblyFilePdb { get; internal set; }

        public List<string> Disgnostics { get; internal set; }

        public Assembly Load()
        {
            return Assembly.LoadFile(this.AssemblyFile);
            
        }

    }

}
