using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bb.Workflow.Service.Models
{

    /// <summary>
    /// provide a model for editing names (domain, version, ...)
    /// </summary>
    [DisplayName("new item")]
    [ValidateAntiForgeryToken]
    public class MdlIncomingFileEditor
    {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required(ErrorMessage = "This argument is required")]
        [DisplayName("Content")]
        [Description("Write the content of the configuration here")]
        public string ModelContent { get; set; }

        /// <summary>
        /// Gets or sets the selected domain.
        /// </summary>
        /// <value>
        /// The selected domain.
        /// </value>
        [Required]
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the selected version.
        /// </summary>
        /// <value>
        /// The selected version.
        /// </value>
        [Required]
        public string Version { get; set; }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; internal set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }
        
    }

}
