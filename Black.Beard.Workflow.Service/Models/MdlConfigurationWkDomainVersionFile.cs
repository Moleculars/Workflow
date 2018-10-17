using System;
using System.Collections.Generic;

namespace Bb.Workflow.Service.Models
{


    /// <summary>
    /// 
    /// </summary>
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

    }

    public class MdlConfigurationWkDomainVersionFile
    {

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; internal set; }
        public string Type { get; internal set; }
        public string[] Path { get; internal set; }
        public DateTime CreationDate { get; internal set; }
        public DateTime LastUpdate { get; internal set; }

    }


}