using Bb.BusinessRule.Configurations;
using Bb.ComponentModel;
using Bb.Core.Documents;
using Bb.Mappings.Configurations;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bb.Workflow.Configurations.Documents.Files
{



    /// <summary>
    /// Reference a folder path for collect all versions of the configuration
    /// </summary>
    public class LocalStorageWorkflowConfigurationProvider : IConfigurationProvider
    {

        public LocalStorageWorkflowConfigurationProvider(DirectoryInfo path)
        {
            
            _path = path;
            _domains = new Dictionary<string, LocalStorageDomainConfiguration>();
            _types = new TypeConfigurations
            (

                new TypeConfiguration("Incoming Messages", "Configuration for incoming messages", "imsg") { Compiler = new IncomingMessageCompiler(), CompileSort = 1 },
                new TypeConfiguration("State Models", "Configuration for states models", "state") { Compiler = new StateMessageCompiler(), CompileSort = 2 },
                new TypeConfiguration("Mapping Models", "Configuration for map incoming models on event state Model", "map") { Compiler = new MappingMessageCompiler(), CompileSort = 3 },
             
                new TypeConfiguration("Func rules", "Function rules to apply on incoming message", "csRules"),
                new TypeConfiguration("Rules", "rules to apply on incoming message", "rules"),

                new TypeConfiguration("Func Workflows", "Function for evaluate workflow", "csworkflows"),
                new TypeConfiguration("Workflows", "workflow's configurations", "workflows")
                
            );
            
        }

        /// <summary>
        /// Gets the list of types of configuration.
        /// </summary>
        /// <value>
        /// The types.
        /// </value>
        public TypeConfigurations Types => _types;
        
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
                        var t = new LocalStorageConfigurationDocumentTemlate(template);
                        Types.Add(t);
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
            return Types.GetByName(type).GetTemplates();
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
        private readonly DirectoryInfo _path;
        private readonly TypeConfigurations _types;

    }

}
