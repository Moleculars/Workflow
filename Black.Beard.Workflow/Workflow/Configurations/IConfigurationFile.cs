using System;

namespace Bb.Workflow
{
    public interface IConfigurationFile
    {

        /// <summary>
        /// Name of the configuration
        /// </summary>
        string Name { get; }

        string[] Path { get; }

        /// <summary>
        /// Type of configuration
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Create date
        /// </summary>
        DateTime CreationDate { get; }

        /// <summary>
        /// last update
        /// </summary>
        DateTime LastUpdate { get; }

    }

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
        DateTime CreationDate { get; }

        /// <summary>
        /// last update
        /// </summary>
        DateTime LastUpdate { get; }

        /// <summary>
        /// Gets the content of the templates.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        string Content { get; }

    }
}
