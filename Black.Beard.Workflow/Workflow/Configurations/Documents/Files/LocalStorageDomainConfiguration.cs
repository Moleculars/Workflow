using Bb.Core.Documents;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Bb.Workflow.Configurations.Documents.Files
{

    public class LocalStorageDomainConfiguration : MemoryDomainConfiguration
    {

        public LocalStorageDomainConfiguration(IConfigurationProvider configurationProvider, string name, string path)
            : base (configurationProvider, name)
        {
            Folder = new DirectoryInfo(path);
        }

        public DirectoryInfo Folder { get; private set; }


        public override bool CreateVersionConfiguration(string name)
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
                Trace.WriteLine(ex);
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

        public override IEnumerable<IConfigurationVersion> GetVersions()
        {
            foreach (LocalStorageConfigurationVersion version in _items.Values)
                yield return version;
        }

        public override IConfigurationVersion GetVersion(string version)
        {
            if (_items.TryGetValue(version, out LocalStorageConfigurationVersion vers))
                return vers;

            return null;

        }

    }

}
