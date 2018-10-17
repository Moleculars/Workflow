using Bb.BusinessRule.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bb.Workflow.Service.Configurations.Documents.Files
{
    public class LocalStorageConfigurationVersion : IConfigurationVersion
    {

        public LocalStorageConfigurationVersion(IDomainConfiguration parent)
        {
            Parent = parent;
        }

        public string Name { get; set; }

        public bool IsDirty { get; set; }

        public DateTime LastUpdate { get; set; }

        public DirectoryInfo Folder { get; internal set; }

        public IEnumerable<IConfigurationFile> Files
        {
            get
            {
                foreach (var item in Folder.GetFiles())
                    yield return new LocalStorageConfigurationFile(item);
            }
        }

        public IDomainConfiguration Parent { get; }

        /// <summary>
        /// Fournit un environement d'évaluation de workflow
        /// </summary>
        /// <returns></returns>
        public /*AnomalyProcessor*/ object BuildProcessor(/* Action<PushedAction> pushAction */)
        {

            //ProcessorWorkflow<ContextAnomaly> wrk = null;   // for debug
            //ConfigConverterWorkflowVisitor wrk2 = null;     // for debug

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
