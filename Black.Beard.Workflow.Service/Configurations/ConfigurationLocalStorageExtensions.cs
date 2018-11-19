using Bb.BusinessRule.Models;
using Bb.Workflow.Parser.Grammar;
using Bb.Workflow.Configurations.Documents.Files;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Bb.ComponentModel;

namespace Bb.Workflow.Service.Configurations
{

    /// <summary>
    /// translate configuration for the website
    /// </summary>
    public static class ConfigurationLocalStorageExtensions
    {

        /// <summary>
        /// Initialize configuration workflow using local storage
        /// </summary>
        /// <param name="hostContextBuilder"></param>
        /// <returns></returns>
        public static HostContextBuilder InitializeLocalStorageWorkflowConfiguration(this HostContextBuilder hostContextBuilder)
        {

            if (string.IsNullOrEmpty(hostContextBuilder.ConfigurationPath))
                throw new ArgumentNullException(nameof(hostContextBuilder.ConfigurationPath));

            var dir = new System.IO.DirectoryInfo(hostContextBuilder.ConfigurationPath);
            if (!dir.Exists)
                dir.Create();

            hostContextBuilder.WorkflowConfiguration = new LocalStorageWorkflowConfigurationProvider(dir);
            hostContextBuilder.WorkflowConfiguration.Initialize();
            return hostContextBuilder;

        }

        /// <summary>
        /// Fournit un environement d'évaluation de workflow
        /// </summary>
        /// <returns></returns>
        private static /*AnomalyProcessor*/ object BuildProcessor(ComponentModel.TypeReferential typeReferential, string path /*, Action<PushedAction> pushAction*/)
        {

            //ProcessorWorkflow<ContextAnomaly> wrk = null;   // for debug
            ConfigConverterWorkflowVisitor wrk2 = null;     // for debug

            ExtendedDataServiceProvider _extendedDataServices = new ExtendedDataServiceProvider(typeReferential, true);

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


        //public static HostContextBuilder AddWorkflowConfiguration(this HostContextBuilder builder)
        //{

        //    var confBuilder = new ConfigurationBuilder()
        //        .SetBasePath(System.AppContext.BaseDirectory)
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
        //        .AddJsonFile("appsettings.dev.json", optional: true, reloadOnChange: false)
        //        .AddEnvironmentVariables();

        //    var configuration = confBuilder.Build();
        //    var config = new WorkflowConfigurationWeb();
        //    configuration.Bind("", config);

        //    //services.AddWorkflowConfiguration(config);

        //    return builder;

        //}

        /// <summary>
        /// register configuration by filename in IOC of web service .net core
        /// </summary>
        /// <param name="hostContextBuilder"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterWorkflowConfiguration(this HostContextBuilder hostContextBuilder, IServiceCollection services)
        {
            services.AddTransient<HostContext>(ctx => hostContextBuilder.CreateLocalContext(ctx));
            return services;
        }

    }
}
