using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Bb.Core.Documents
{
    public class CompiledConfiguration
    {

        public CompiledConfiguration()
        {
            Diagnostics = new List<CheckResult>();
        }

        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        /// <value>
        /// The domain.
        /// </value>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version { get; set; }

        public List<CheckResult> Diagnostics { get; }

        public string AssemblyPath { get; set; }

        public bool Valid { get; set; }
        
        public Assembly LoadAssembly()
        {
            Trace.WriteLine($"Loading assembly {AssemblyPath}");
            return Assembly.LoadFile(AssemblyPath);
        }

    }

}
