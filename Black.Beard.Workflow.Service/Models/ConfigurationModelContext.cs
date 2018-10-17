using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bb.Workflow.Service.Models
{

    public class ConfigurationModelContext : ModelContext
    {

        /// <summary>
        /// List of mapped configurations
        /// </summary>
        public List<MdlConfigurationWkDomain> ConfigurationList { get; internal set; }

        /// <summary>
        /// Gets the selected domain.
        /// </summary>
        /// <value>
        /// The selected domain.
        /// </value>
        public string SelectedDomain { get; internal set; }

        /// <summary>
        /// Gets the selected version.
        /// </summary>
        /// <value>
        /// The selected version.
        /// </value>
        public string SelectedVersion { get; internal set; }
    }

}
