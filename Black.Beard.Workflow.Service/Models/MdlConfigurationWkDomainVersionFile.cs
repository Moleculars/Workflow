using Bb.Core;
using Bb.Core.Documents;
using System;
using System.Diagnostics;

namespace Bb.Workflow.Service.Models
{


    /// <summary>
    /// MdlConfigurationWkDomainVersionFile
    /// </summary>
    [DebuggerDisplay("ver : {Name}")]
    public class MdlConfigurationWkDomainVersionFile
    {

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; internal set; }
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; internal set; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string[] Path { get; internal set; }

        /// <summary>
        /// Gets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTimeOffset CreationDate { get; internal set; }

        /// <summary>
        /// Gets the last update.
        /// </summary>
        /// <value>
        /// The last update.
        /// </value>
        public DateTimeOffset LastUpdate { get; internal set; }

        /// <summary>
        /// Gets the type configuration.
        /// </summary>
        /// <value>
        /// The type configuration.
        /// </value>
        public TypeConfiguration TypeConfiguration { get; internal set; }

    }


}