using Bb.BusinessRule.Models;
using Bb.Workflow.Models;
using System;
using System.Collections.Generic;
using Bb.Workflow.Configurations;
using Bb.Workflow.Validators;
using Bb.Workflow.Contracts;
using Bb.Workflow.Configurations.Rules;
using Bb.Core.LocalQueue;

namespace Bb.Workflow
{

    /// <summary>
    /// Evaluate events and process workflows
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    /// <typeparam name="TSourceEvent"></typeparam>
    /// <typeparam name="TWorkflowStateModel"></typeparam>
    public class WorkflowManagerProcessor<TContext, TSourceEvent, TWorkflowStateModel>
        where TContext : ContextWorkflow<TWorkflowStateModel, TSourceEvent>, new()
        where TSourceEvent : ISourceEvent
        where TWorkflowStateModel : WorkflowModel
    {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="businessRules"></param>
        /// <param name="contextStorageService"></param>
        /// <param name="validator"></param>
        public WorkflowManagerProcessor(RuleServiceProviderLoader<TSourceEvent, TContext> ruleService, EventValidator<TSourceEvent> validator, DataServiceSelector<TWorkflowStateModel, TSourceEvent> eventSelector, ExtendedDataServiceProvider extendedDataServices, LQueue<PushedAction> queueOutput)
        {
            this._brService = ruleService ?? throw new ArgumentNullException(nameof(ruleService));
            this._validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this._eventSelector = eventSelector ?? throw new ArgumentNullException(nameof(eventSelector));
            this._extendedDataServices = extendedDataServices ?? throw new ArgumentNullException(nameof(extendedDataServices));
            this._output = _output ?? throw new ArgumentNullException(nameof(_output));
            ruleService.Register();

        }


        public List<TWorkflowStateModel> Evaluate(TSourceEvent @event)
        {

            List<TWorkflowStateModel> result = new List<TWorkflowStateModel>();

            TContext context = GetContext();
            context.SourceEvent = @event;

            List<ResultModel> _results = new List<ResultModel>();

            // resolve data context service
            IDataService<TWorkflowStateModel, TSourceEvent> WorkflowCrud = this._eventSelector.GetContextFor(context);

            // Get all existing workflows on the context
            var items = WorkflowCrud.ReadItems(@event);

            // Evaluate the rule's processor to used
            var ruleProvider = this._brService.GetRules(context.SourceEvent);
            var rules = ruleProvider.GetBusinessRules();
            context.RuleCrc = ruleProvider.Crc;

            // load additionals datas
            ruleProvider.LoadDatas(context);

            if (items.Count > 0)        // Evaluate for every anomaly
                foreach (TWorkflowStateModel item in items)
                {
                    context.Workflow = item;
                    result.Add(Evaluate(context, WorkflowCrud, rules));
                }

            else                        // Evaluate for no anomaly
            {
                var r = Evaluate(context, WorkflowCrud, rules);
                if (r != null)
                    result.Add(r);
            }

            return result;

        }

        /// <summary>
        /// Evaluate rule's processor and return in results the list of action
        /// </summary>
        /// <param name="context"></param>
        /// <param name="results"></param>
        /// <param name="workflowCrud"></param>
        /// <returns></returns>
        private TWorkflowStateModel Evaluate(TContext context, IDataService<TWorkflowStateModel, TSourceEvent> workflowCrud, Action<TContext, List<ResultModel>> rules)
        {

            var results = context.EventResults;

            results.Clear();

            // Evaluate rules
            rules(context, results);

            int count = results.Count;
            if (count > 0)
                foreach (ResultModel result in results)
                {

                    if (context.Workflow == null)
                        context.Workflow = workflowCrud.Create(result.FamilyObject, result.ObjectName, (TSourceEvent)context.SourceEvent);
                    workflowCrud.AppendEvent((TSourceEvent)context.SourceEvent, context.Workflow);

                    result.ResultEvaluationWorkflow = EvaluateEventInWorkflow(context);
                    PushActions(context.ActionToExecutes);

                    workflowCrud.Save(context.Workflow);

                }
            else
            {

                var act = new PushedAction()
                {
                    ActionComment = Constants.Ok,
                    ActionName = Constants.Ok,
                    Arguments = new List<string>(),
                    Event = context.SourceEvent,
                    Workflow = null,
                };
                this._output.Execute(act);

            }

            return context.Workflow;

        }

        private void PushActions(IEnumerable<PushedAction> pushedActions)
        {
            foreach (PushedAction action in pushedActions)
                this._output.Execute(action);
        }

        private bool EvaluateEventInWorkflow(TContext context)
        {

            bool result = false;

            if (context.Workflow.WorkflowInstance is ProcessorWorkflow<TContext> wk)
            {

                if (context.Workflow != null && string.IsNullOrEmpty(context.Workflow.CurrentStateKey))
                    context.Workflow.CurrentStateKey = wk.InitialState.Key;

                while (wk.Evaluate(context))
                    result = true;

            }

            return result;

        }

        protected TContext GetContext()
        {
            var ctx = new TContext
            {
                DataServices = this._extendedDataServices
            };
            return ctx;
        }

        public LQueue<PushedAction> Output { get; set; }


        private readonly RuleServiceProviderLoader<TSourceEvent, TContext> _brService;
        private readonly EventValidator<TSourceEvent> _validator;
        private readonly DataServiceSelector<TWorkflowStateModel, TSourceEvent> _eventSelector;
        private readonly ExtendedDataServiceProvider _extendedDataServices;
        private readonly LQueue<PushedAction> _output;
    }

}
