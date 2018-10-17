using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bb.Workflow.Service.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class MdlConfigurationWkDomain
    {

        /// <summary>
        /// Ctor
        /// </summary>
        public MdlConfigurationWkDomain()
        {
            this.Versions = new List<MdlConfigurationWkDomainVersion>();
        }

        /// <summary>
        /// List of versions
        /// </summary>
        public List<MdlConfigurationWkDomainVersion> Versions { get; }

        /// <summary>
        /// Name of the domain workflow
        /// </summary>
        public string Name { get; set; }

    }

}
