using System;

namespace Bb.Core.Documents
{
    public interface IConfigurationTemplateFile
    {

        /// <summary>
        /// Name of the configuration
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Type of configuration
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Create date
        /// </summary>
        DateTimeOffset CreationDate { get; }

        /// <summary>
        /// last update
        /// </summary>
        DateTimeOffset LastUpdate { get; }

        /// <summary>
        /// Gets the content of the templates.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        string Content { get; }

    }
}
