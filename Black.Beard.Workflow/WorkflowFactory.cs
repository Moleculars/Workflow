//using Bb.BusinessRule.Models;
//using Bb.Core;
//using Bb.Core.Helpers;
//using Bb.Core.LocalQueue;
//using Bb.Workflow;
//using Bb.Workflow.Configurations;
//using Bb.Workflow.Configurations.Rules.Providers;
//using Bb.Workflow.Contracts;
//using Bb.Workflow.Models;
//using Bb.Workflow.Parser.Grammar;
//using Bb.Workflow.Providers;
//using Bb.Workflow.Validators;
//using System;
//using System.Collections.Generic;

//namespace Bb
//{

//    public class WorkflowFactory<TContext, TSourceEvent, TWorkflowStateModel>
//        where TContext : ContextWorkflow<TWorkflowStateModel, TSourceEvent>, IWorkflowContext, new()
//        where TSourceEvent : ISourceEvent
//        where TWorkflowStateModel : WorkflowModel, IWorkflowState, new()

//    {

//        public WorkflowFactory()
//        {
//            ProcessorWorkflow<TContext> wrk = null;   // for debug
//            ConfigConverterWorkflowVisitor wrk2 = null;     // for debug
//        }

//        public WorkflowManagerProcessor<TContext, TSourceEvent, TWorkflowStateModel> BuildProcessor(string path, ComponentModel.TypeReferential typeReferential, Action<PushedAction> pushAction, string[] stateKinds)
//        {

//            ExtendedDataServiceProvider _extendedDataServices = new ExtendedDataServiceProvider(typeReferential, true);

//            // fournisseur de regle conversion d'evenement d'entrée en event workflow
//            var ruleService = new RuleServiceProviderOnFiles<TSourceEvent, TContext>(path);

//            // fournisseur de regle de workflow
//            var workflow = new WorkflowServiceProviderOnFiles<TSourceEvent, TContext>(path);

//            var validator = new WorkflowEventValidator<TSourceEvent, TContext>(workflow);
//            var dataService = new WorkflowDataService<TSourceEvent, TWorkflowStateModel, TContext>(workflow);

//            // le selector permet de choisir le bon context de chargement des données
//            DataServiceSelector<TWorkflowStateModel, TSourceEvent> selector = new DataServiceSelector<TWorkflowStateModel, TSourceEvent>();

//            foreach (var stateKind in stateKinds)
//                selector.Append(stateKind, dataService);

//            var output = new LQueue<PushedAction>(path, pushAction, m => m.Save(), txt => PushedAction.Load(txt), m => m.Event.Uid.ToString());

//            var processor = new WorkflowManagerProcessor<TContext, TSourceEvent, TWorkflowStateModel>(ruleService, validator, selector, _extendedDataServices, output);

//            return processor;

//        }

//    }

//    public class WorkflowDataService<TSourceEvent, TWorkflowStateModel, TContext> : IDataService<TWorkflowStateModel, TSourceEvent>
//        where TSourceEvent : ISourceEvent
//        where TWorkflowStateModel : WorkflowModel, IWorkflowState, new()
//        where TContext : IWorkflowContext

//    {

//        /// <summary>
//        /// Ctor
//        /// </summary>
//        /// <param name="workflowService"></param>
//        public WorkflowDataService(WorkflowService<TSourceEvent, TContext> workflowService)
//        {
//            _workflowService = workflowService;
//            _workflowService.Register();
//        }

//        /// <summary>
//        /// Create a new workflow model
//        /// </summary>
//        /// <param name="kindObject"></param>
//        /// <param name="objectName"></param>
//        /// <param name="event"></param>
//        /// <returns></returns>
//        public TWorkflowStateModel Create(string kindObject, string objectName, TSourceEvent @event)
//        {

//            ProcessorWorkflow<TContext> wk = _workflowService.GetWorkflow(@event);

//            var anomalie = new TWorkflowStateModel()
//            {

//                Uid = Guid.NewGuid(),
//                Kind = objectName,
//                ExternalKey = @event.Id,

//                CurrentStateKey = wk.InitialState.Key,
//                ProcessorCrc = wk.Crc,

//                WorkflowInstance = wk,


//            };

//            // Intercept 

//            return anomalie;

//        }

//        /// <summary>
//        /// Append new event in the workflow model
//        /// </summary>
//        /// <param name="event"></param>
//        /// <param name="workflow"></param>
//        public void AppendEvent(TSourceEvent @event, TWorkflowStateModel workflow)
//        {

//            var e = new StateEvent()
//            {
//                Uid = @event.Uid,
//                Key = @event.Key,
//                EventDate = @event.EventDate,
//                IntegratedAt = LocalClock.GetNow,

//                PostDate = @event.PostDate,

//                FromWorkflowState = workflow.CurrentStateKey,
//                ToWorkflowSState = workflow.CurrentStateKey,

//            };

//            // Comment rentrer dans l'objet les proprietes de l'objet dynamic ???
//            workflow.Events.Add(e);

//        }

//        /// <summary>
//        /// Drop workflow model
//        /// </summary>
//        /// <param name="kindObject"></param>
//        /// <param name="objectName"></param>
//        /// <param name="state"></param>
//        public void Drop(string kindObject, string objectName, TWorkflowStateModel state)
//        {

//        }

//        /// <summary>
//        /// Load from storage all existing workflow models 
//        /// </summary>
//        /// <param name="event"></param>
//        /// <returns></returns>
//        public List<TWorkflowStateModel> ReadItems(TSourceEvent @event)
//        {
//            var items = new List<TWorkflowStateModel>();
//            return items;
//        }

//        /// <summary>
//        /// Store the model
//        /// </summary>
//        /// <param name="state"></param>
//        public void Save(TWorkflowStateModel state)
//        {

//        }

//        private readonly WorkflowService<TSourceEvent, TContext> _workflowService;

//    }

//}
