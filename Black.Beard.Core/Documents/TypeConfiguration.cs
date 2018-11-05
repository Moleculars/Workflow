using System;
using System.Collections.Generic;

namespace Bb.Core.Documents
{

    public class TypeConfiguration
    {

        public TypeConfiguration(string name, string description, string extension)
        {
            Name = name;
            Description = description;
            Extension = extension;

            this._templates = new List<IConfigurationTemplateFile>();

        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; }

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        public string Extension { get; }

        public IConfigurationDocumentCompiler Compiler { get; set; }

        internal void Add(IConfigurationTemplateFile template)
        {
            this._templates.Add(template);
        }

        public List<IConfigurationTemplateFile> GetTemplates()
        {
            return this._templates;
        }

        private readonly List<IConfigurationTemplateFile> _templates;

    }

}
