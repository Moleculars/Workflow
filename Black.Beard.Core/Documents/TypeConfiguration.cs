using System;
using System.Collections.Generic;

namespace Bb.Core.Documents
{

    public class TypeConfiguration
    {

        static TypeConfiguration()
        {
            PreCompileLimit = 10;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeConfiguration"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="extension">The extension.</param>
        public TypeConfiguration(string name, string description, string extension)
        {
            Name = name;
            Description = description;
            Extension = extension;

            _templates = new List<IConfigurationTemplateFile>();
            
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

        public bool PostCompile => CompileSort >= PreCompileLimit;

        public int CompileSort { get; set; }

        internal void Add(IConfigurationTemplateFile template)
        {
            _templates.Add(template);
        }

        public List<IConfigurationTemplateFile> GetTemplates()
        {
            return _templates;
        }

        private readonly List<IConfigurationTemplateFile> _templates;

        public readonly static int PreCompileLimit;


    }

}
