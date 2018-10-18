using System.Collections.Generic;

namespace Bb.Workflow
{
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

}
