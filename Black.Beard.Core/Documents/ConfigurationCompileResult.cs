using System.Collections.Generic;

namespace Bb.Core.Documents
{
    public class ConfigurationCompileResult
    {

        public ConfigurationCompileResult()
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

        /// <summary>
        /// Gets or sets the assembly compiler.
        /// </summary>
        /// <value>
        /// <see cref="Bb.Core.CompileResult"/> result of assembly complier
        /// </value>
        public object AssemblyCompiler { get; set; }

        public List<CheckResult> Diagnostics { get; }

    }

}
