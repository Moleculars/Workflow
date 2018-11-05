using Bb.Core.Documents;
using Bb.Workflow.Configurations.Documents.Files;
using System.Collections.Generic;

namespace Bb.Workflow.Configurations.Documents
{
    public abstract class MemoryDomainConfiguration : IDomainConfiguration
    {

        public MemoryDomainConfiguration(IConfigurationProvider configurationProvider, string name)
        {
            Parent = configurationProvider;
            Name = name;
            _items = new Dictionary<string, LocalStorageConfigurationVersion>();

        }

        public IConfigurationProvider Parent { get; }

        public string Name { get; set; }

        public abstract bool CreateVersionConfiguration(string name);

        public abstract IEnumerable<IConfigurationVersion> GetVersions();

        public abstract IConfigurationVersion GetVersion(string version);

        protected readonly Dictionary<string, LocalStorageConfigurationVersion> _items;

    }

}
