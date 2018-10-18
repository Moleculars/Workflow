using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            this._domains = new Dictionary<string, LocalStorageDomainConfiguration>();
            this._templates = new Dictionary<string, IConfigurationTemplateFile>();

        }

        /// <summary>
        /// Parse all folder and lLoad all configuration in memory
        /// </summary>
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

            _path.Refresh();

            try
            {
                var dir = _path.CreateSubdirectory(name);
                EnsureLoaded(dir);

                return true;
            }
            catch (System.Exception ex)
            {

                throw;
            }

            return false;

        }

        private void EnsureLoaded(DirectoryInfo configuration)
        {

            switch (configuration.Name)
            {
                case "_templates":
                    foreach (FileInfo template in configuration.GetFiles())
                    {
                        var t = new LocalStorageConfigurationFileTemlate(template);
                        this._templates.Add(t.Name, t);
                    }
                    break;

                default:    // Domains
                    {
                        LocalStorageDomainConfiguration config = new LocalStorageDomainConfiguration(this, configuration.Name, configuration.FullName);
                        config.Initialize(configuration);
                        if (_domains.ContainsKey(config.Name))
                            _domains[config.Name] = config;
                        else
                            _domains.Add(config.Name, config);
                    }
                    break;
            }


        }

        /// <summary>
        /// Gets the template list for the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public List<IConfigurationTemplateFile> GetTemplateFiles(string type)
        {
            var t = type.ToLowerInvariant();

            List<IConfigurationTemplateFile> result = this._templates
                .Values
                .Where(c => c.Type.ToLowerInvariant() == t).Cast<IConfigurationTemplateFile>()
                .ToList();

            return result;

        }


        public IEnumerable<IDomainConfiguration> GetDomainConfigurations()
        {
            foreach (var item in _domains.Values)
                yield return item;
        }

        public IDomainConfiguration GetDomainConfiguration(string domain)
        {
            if (_domains.TryGetValue(domain, out LocalStorageDomainConfiguration _dom))
                return _dom;
            return null;
        }

        private readonly Dictionary<string, LocalStorageDomainConfiguration> _domains;
        private readonly Dictionary<string, IConfigurationTemplateFile> _templates;
        private readonly DirectoryInfo _path;

    }

}
