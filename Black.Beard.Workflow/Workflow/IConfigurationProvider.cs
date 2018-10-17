using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Workflow
{

    public interface IConfigurationProvider
    {

        /// <summary>
        /// Load all configuration in memory
        /// </summary>
        void Initialize();

        /// <summary>
        /// Load one configuration in memory
        /// </summary>
        /// <param name="configurationName"></param>
        void Initialize(string configurationName);

        IEnumerable<IDomainConfiguration> GetDomainConfigurations();

        IDomainConfiguration GetDomainConfiguration(string domain);

        /// <summary>
        /// Creates a new domain configuration.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        bool CreateDomainConfiguration(string name);

    }

    public interface IDomainConfiguration
    {

        IConfigurationProvider Parent { get; }

        string Name { get; set; }

        IEnumerable<IConfigurationVersion> GetVersions();

        IConfigurationVersion GetVersion(string version);

        /// <summary>
        /// Creates a new version configuration in the current domain.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        bool CreateVersionConfiguration(string name);

    }

    public interface IConfigurationVersion
    {

        IDomainConfiguration Parent { get; }

        string Name { get; set; }

        bool IsDirty { get; set; }

        DateTime LastUpdate { get; set; }

        IEnumerable<IConfigurationFile> Files { get; }

    }

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

}
