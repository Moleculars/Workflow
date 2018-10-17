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
    public class MdlNameEditor
    {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required(ErrorMessage = "This argument is required")]
        [DisplayName("Name")]
        [Description("Write the name of the new item here")]
        [RegularExpression(@"\w+")]
        [StringLength(50, ErrorMessage ="this argument must be less than {1} characters")]
        [MinLength(3,  ErrorMessage ="this argument must be great than {1} characters")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the selected domain.
        /// </summary>
        /// <value>
        /// The selected domain.
        /// </value>
        [Required]
        public string SelectedDomain { get; set; }

        /// <summary>
        /// Gets or sets the selected version.
        /// </summary>
        /// <value>
        /// The selected version.
        /// </value>
        [Required]
        public string SelectedVersion { get; set; }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; internal set; }

        /// <summary>
        /// Gets the domain.
        /// </summary>
        /// <value>
        /// The domain.
        /// </value>
        public string Domain { get; set; }

    }

}
