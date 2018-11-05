using Bb.Core;
using Bb.Core.Documents;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bb.Workflow.Service.Models
{

    /// <summary>
    /// MdlConfigurationWkDomainVersionFileByType
    /// </summary>
    [DebuggerDisplay("type : {Type}")]
    public class MdlConfigurationWkDomainVersionFileByType
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MdlConfigurationWkDomainVersionFileByType"/> class.
        /// </summary>
        public MdlConfigurationWkDomainVersionFileByType()
        {
            Files = new List<MdlConfigurationWkDomainVersionFile>();
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; internal set; }

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public List<MdlConfigurationWkDomainVersionFile> Files { get; }

        /// <summary>
        /// Gets the type of the configuration.
        /// </summary>
        /// <value>
        /// The type of the configuration.
        /// </value>
        public TypeConfiguration ConfigurationType { get; internal set; }
    }


}