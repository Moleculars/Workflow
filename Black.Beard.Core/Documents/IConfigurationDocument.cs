using System;
using System.Text;

namespace Bb.Core.Documents
{
    public interface IConfigurationDocument
    {

        /// <summary>
        /// Name of the configuration
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Create date
        /// </summary>
        DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// last update
        /// </summary>
        DateTimeOffset LastUpdate { get; set; }

        /// <summary>
        /// Gets the version parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        IConfigurationVersion Parent { get; }

        /// <summary>
        /// Gets the type of configurations.
        /// </summary>
        /// <value>
        /// The type configurations.
        /// </value>
        TypeConfiguration TypeConfiguration { get; }

        /// <summary>
        /// Gets the content of the configuration.
        /// </summary>
        /// <returns></returns>
        StringBuilder Content { get; set; }

        /// <summary>
        /// Renames the configuration with specified new name.
        /// </summary>
        /// <param name="newName">The new name.</param>
        /// <returns></returns>
        bool Rename(string newName);

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns></returns>
        bool Delete();
        void Save();
    }
}

