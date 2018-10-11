using Bb.BusinessRule.Models;
using Bb.Workflow.Parser.Grammar;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bb.Workflow.Service.Configurations
{

    /// <summary>
    /// Reference a folder path for collect all versions of the configuration
    /// </summary>
    public class LocalStorageWorkflowConfigurationProvider : IConfigurationProvider
    {

        public LocalStorageWorkflowConfigurationProvider(DirectoryInfo path)
        {
            _path = path;
            _dictionary = new Dictionary<string, LocalStorageWorkflowConfiguration>();
        }

        public void Initialize()
        {
            foreach (var item in this._path.GetDirectories())
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

        private void EnsureLoaded(DirectoryInfo globalConfiguration)
        {
            LocalStorageWorkflowConfiguration config = new LocalStorageWorkflowConfiguration(this, globalConfiguration.Name, globalConfiguration.FullName);
            config.Initialize(globalConfiguration);
            if (_dictionary.ContainsKey(config.Name))
                _dictionary[config.Name] = config;
            else
                _dictionary.Add(config.Name, config);
        }

        public IEnumerable<IGlobalConfiguration> GetConfigurations()
        {
            throw new NotImplementedException();
        }


        //public IEnumerable<StringBuilder> GetConfigurations(string name)
        //{
        //    throw new NotImplementedException();
        //}

        private readonly Dictionary<string, LocalStorageWorkflowConfiguration> _dictionary;
        private readonly DirectoryInfo _path;

    }


    public class LocalStorageWorkflowConfiguration : IGlobalConfiguration
    {

        public LocalStorageWorkflowConfiguration(IConfigurationProvider configurationProvider, string name, string path)
        {
            Parent = configurationProvider;
            Name = name;
            _items = new Dictionary<string, LocalStorageGlobalConfigurationListItem>();
            this._path = path;
        }

        public IConfigurationProvider Parent { get; }

        public string Name { get; set; }
        public DirectoryInfo Folder { get; private set; }

        internal void Initialize(DirectoryInfo globalConfiguration)
        {

            globalConfiguration.Refresh();
            foreach (var version in globalConfiguration.GetDirectories())
                Load(version);

            if (!_items.ContainsKey("current"))
            {
                var dir = new DirectoryInfo(Path.Combine(this._path, "current"));
                dir.Create();
                Load(dir);
            }

        }
      
        public void Load(DirectoryInfo version)
        {

            LocalStorageGlobalConfigurationListItem item = new LocalStorageGlobalConfigurationListItem()
            {
                Folder = version,
                Name = version.Name,
                LastUpdate = version.LastWriteTimeUtc,
            };

            LocalStorageGlobalConfigurationListItem.BuildProcessor(version.FullName);

            if (_items.ContainsKey(item.Name))
                _items[item.Name] = item;
            else
                _items.Add(item.Name, item);

        }

        private readonly Dictionary<string, LocalStorageGlobalConfigurationListItem> _items;
        private readonly string _path;

    }


    public class LocalStorageGlobalConfigurationListItem
    {

        public string Name { get; set; }

        public bool IsDirty { get; set; }

        public DateTime LastUpdate { get; set; }

        public DirectoryInfo Folder { get; internal set; }

        /// <summary>
        /// Fournit un environement d'évaluation de workflow
        /// </summary>
        /// <returns></returns>
        public /*AnomalyProcessor*/ object BuildProcessor(/* Action<PushedAction> pushAction */)
        {

            //ProcessorWorkflow<ContextAnomaly> wrk = null;   // for debug
            ConfigConverterWorkflowVisitor wrk2 = null;     // for debug

            ExtendedDataServiceProvider _extendedDataServices = new ExtendedDataServiceProvider(true);

            // fournisseur de regle conversion d'evenement d'entrée en event workflow
            //var ruleService = new RuleServiceProviderOnFiles<Colis21Event, ContextAnomaly>(path);

            // fournisseur de regle de workflow
            //var workflow = new WorkflowServiceProviderOnFiles<Colis21Event, ContextAnomaly>(path);

            //var validator = new WorkflowEventValidator<Colis21Event, ContextAnomaly>(workflow);
            //var anomalyService = new AnomalyColisDataService(workflow);

            // le selector permet de choisir le bon context de chargement des données
            //var selector = new AnomalyDataServiceSelector();
            //selector.Append(stateKind, anomalyService);

            //var output = new LQueue<PushedAction>(path, pushAction, m => m.Save(), txt => PushedAction.Load(txt), m => m.Event.Uid.ToString());

            //var processor = new AnomalyProcessor(ruleService, validator, selector, _extendedDataServices, output);

            //return processor;

            throw new NotImplementedException();

        }


    }

}
