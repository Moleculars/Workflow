using System.Collections.Generic;
using System.IO;

namespace Bb.Workflow.Service.Configurations.Documents.Files
{
    public class LocalStorageDomainConfiguration : IDomainConfiguration
    {

        public LocalStorageDomainConfiguration(IConfigurationProvider configurationProvider, string name, string path)
        {
            Parent = configurationProvider;
            Name = name;
            _items = new Dictionary<string, LocalStorageConfigurationVersion>();
            Folder = new DirectoryInfo(path);
        }

        public IConfigurationProvider Parent { get; }

        public string Name { get; set; }

        public DirectoryInfo Folder { get; private set; }


        public bool CreateVersionConfiguration(string name)
        {

            Folder.Refresh();

            try
            {
                var dir = Folder.CreateSubdirectory(name);
                Load(dir);
                return true;
            }
            catch (System.Exception ex)
            {

                throw;
            }

            return false;

        }

        internal void Initialize(DirectoryInfo globalConfiguration)
        {

            globalConfiguration.Refresh();
            foreach (var version in globalConfiguration.GetDirectories())
                Load(version);

            if (!_items.ContainsKey("current"))
            {
                var dir = new DirectoryInfo(Path.Combine(Folder.FullName, "current"));
                dir.Create();
                Load(dir);
            }

        }

        public void Load(DirectoryInfo version)
        {

            LocalStorageConfigurationVersion item = new LocalStorageConfigurationVersion(this)
            {
                Folder = version,
                Name = version.Name,
                LastUpdate = version.LastWriteTimeUtc,
            };

            //LocalStorageGlobalConfigurationListItem.BuildProcessor(version.FullName);

            if (_items.ContainsKey(item.Name))
                _items[item.Name] = item;
            else
                _items.Add(item.Name, item);

        }

        public IEnumerable<IConfigurationVersion> GetVersions()
        {
            foreach (LocalStorageConfigurationVersion version in _items.Values)
                yield return version;
        }

        public IConfigurationVersion GetVersion(string version)
        {
            if (_items.TryGetValue(version, out LocalStorageConfigurationVersion vers))
                return vers;

            return null;

        }

        private readonly Dictionary<string, LocalStorageConfigurationVersion> _items;

    }

}
