using Bb.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Bb.Core.Documents
{

    public interface IConfigurationProvider
    {

        /// <summary>
        /// Load all configuration in memory
        /// </summary>
        void Initialize();

        TypeDiscovery TypeResolver { get; } 
        
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

        /// <summary>
        /// Gets the template list for the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        List<IConfigurationTemplateFile> GetTemplateFiles(string type);

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <value>
        /// The types.
        /// </value>
        TypeConfigurations Types { get; }

    }

}
