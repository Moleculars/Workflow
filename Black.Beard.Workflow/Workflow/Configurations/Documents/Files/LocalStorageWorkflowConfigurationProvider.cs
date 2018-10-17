using System;
using System.Collections.Generic;
using System.IO;

namespace Bb.Workflow.Service.Configurations.Documents.Files
{

    /// <summary>
    /// Reference a folder path for collect all versions of the configuration
    /// </summary>
    public class LocalStorageWorkflowConfigurationProvider : IConfigurationProvider
    {

        public LocalStorageWorkflowConfigurationProvider(DirectoryInfo path)
        {
            _path = path;
            _dictionary = new Dictionary<string, LocalStorageDomainConfiguration>();
        }

        public void Initialize()
        {
            foreach (var item in _path.GetDirectories())
                EnsureLoaded(item);
        }

        public void Initialize(string configurationName)
        {
            var p = new DirectoryInfo(Path.Combine(_path.FullName, configurationName));
            if (p.Exists)
                EnsureLoaded(p);

            else
                throw new Exception("missing configuration " + configurationName);

            p.Refresh();

        }

        public bool CreateDomainConfiguration(string name)
        {

            this._path.Refresh();

            try
            {
                var dir = this._path.CreateSubdirectory(name);
                EnsureLoaded(dir);

                return true;
            }
            catch (System.Exception ex)
            {

                throw;
            }

                return false;

        }

        private void EnsureLoaded(DirectoryInfo globalConfiguration)
        {
            LocalStorageDomainConfiguration config = new LocalStorageDomainConfiguration(this, globalConfiguration.Name, globalConfiguration.FullName);
            config.Initialize(globalConfiguration);
            if (_dictionary.ContainsKey(config.Name))
                _dictionary[config.Name] = config;
            else
                _dictionary.Add(config.Name, config);
        }

        public IEnumerable<IDomainConfiguration> GetDomainConfigurations()
        {
            foreach (var item in _dictionary.Values)
                yield return item;
        }

        public IDomainConfiguration GetDomainConfiguration(string domain)
        {
            if (_dictionary.TryGetValue(domain, out LocalStorageDomainConfiguration _dom))
                return _dom;
            return null;
        }

        private readonly Dictionary<string, LocalStorageDomainConfiguration> _dictionary;
        private readonly DirectoryInfo _path;

    }

}
