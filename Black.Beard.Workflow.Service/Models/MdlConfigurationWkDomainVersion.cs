using System.Collections.Generic;

namespace Bb.Workflow.Service.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class MdlConfigurationWkDomainVersion
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="MdlConfigurationWkDomainVersion"/> class.
        /// </summary>
        public MdlConfigurationWkDomainVersion()
        {
            Types = new List<MdlConfigurationWkDomainVersionFileByType>();
        }

        /// <summary>
        /// Name of the version
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Domain { get; set; }

        /// <summary>
        /// Name of the version
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// List of the files
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public List<MdlConfigurationWkDomainVersionFileByType> Types { get; }

    }

}
