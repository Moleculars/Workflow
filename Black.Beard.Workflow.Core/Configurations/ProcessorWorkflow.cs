using Bb.ComponentModel;
using Bb.Workflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Workflow.Configurations
{

    /// <summary>
    /// Processor for manage workflow
    /// </summary>
    public class ProcessorWorkflow<TContext> where TContext : IWorkflowContext
    {

        public ProcessorWorkflow(WorkflowDefinitionModel config)
        {

            this._config = config ?? throw new ArgumentNullException(nameof(config));
            if (this._config.Errors.Any())
                throw new Exception($"the configuration have errors");

            this.InitialState = this._config.States.FirstOrDefault(c => c.IsInitial);

            this.Matchings = config.Matchings;

            this.Events = config.Events.ToDictionary(c => c.Key);
            this.Rules = config.Rules.ToDictionary(c => c.Key);

        }

        public uint Crc { get => this._config.Crc; }

        public StateDefinitionModel InitialState { get; }

        public List<List<KeyValuePair<string, string>>> Matchings { get; }

        public IDictionary<string, EventDefinitionModel> Events { get; }

        public IDictionary<string, RuleDefinitionModel> Rules { get; }

        /// <summary>
        /// Evaluate impact of th event on the state
        /// </summary>
        /// <param name="event"></param>
        /// <param name="state"></param>
        /// <returns>return true if the current state have changed</returns>
        public bool Evaluate(TContext context)
        {

            ISourceEvent @event = context.SourceEvent;
            IWorkflowState state = context.Workflow;

            // histo previous state
            var c1 = state.CurrentStateKey;

            // Find the state by name in the config
            StateDefinitionModel currentState = this._config.ResolveState(state.CurrentStateKey);

            // Resolve Event in available list for the current state. (note it is possible the resulte is no event if switch exists)
            OnEventReferenceModel e = currentState.ResolveEvent(@event.Key);

            if (e != null) // Event found
                Evaluate(context, currentState, e);

            return c1 != state.CurrentStateKey;

        }

        private void Evaluate(TContext context, StateDefinitionModel currentState, OnEventReferenceModel e)
        {

            ISourceEvent @event = context.SourceEvent;
            IWorkflowState state = context.Workflow;

            foreach (var _switch in e.Switchs)
            {

                if (_switch.When != null)  // condition to evaluate
                    if (!_switch.When.Evaluate<TContext>(context))
                        continue;   // evaluate return false

                StateDefinitionModel nextState = null;
                if (!string.IsNullOrEmpty(_switch.Key))
                    nextState = this._config.ResolveState(_switch.Key); //find nexte state for the specified event.

                if (nextState != null)
                {

                    RunOnExit(context, currentState, _switch, nextState, context.ActionToExecutes);

                    state.CurrentStateKey = nextState.Key;
                    RunOnEnter(context, nextState, context.ActionToExecutes);

                    break;

                }

            }
        }

        private void RunOnEnter(TContext context, StateDefinitionModel nextState, List<PushedAction> actionResults)
        {

            // Les actions specifiques au prochain état à executer avant d'entrer
            foreach (ActionReferenceModel toExecute in nextState.ToExecutes)
                if ((toExecute.Way & OnEventEnum.OnEnter) == OnEventEnum.OnEnter)
                    actionResults.Add(toExecute.Reference.PushAction(toExecute, context.SourceEvent, context.Workflow));

            foreach (var e in nextState.Events.Where(c => c.Delay > 0))
            {

                var p = new PushedAction()
                {
                    ActionName = "[[WAITING]]",
                    ActionComment = "Out of time",
                    Arguments = new List<string>() { e.Delay.ToString() },
                    Event = context.SourceEvent,
                    Workflow = context.Workflow
                };
                actionResults.Add(p);

            }

        }

        private void RunOnExit(TContext context, StateDefinitionModel currentState, SwitchDefinitionModel _switch, StateDefinitionModel nextState, List<PushedAction> actionResults)
        {

            if (_switch.Delay > 0)
            {
                var p = new PushedAction()
                {
                    ActionName = "[[STOP WAITING]]",
                    ActionComment = "stop waiting time out on the current state",
                    Event = context.SourceEvent,
                    Workflow = context.Workflow
                };
                actionResults.Add(p);

            }

            // Les actions de l'état courant a executer avant de sortir
            foreach (ActionReferenceModel toExecute in currentState.ToExecutes)
                if ((toExecute.Way & OnEventEnum.OnExit) == OnEventEnum.OnExit)
                    actionResults.Add(toExecute.Reference.PushAction(toExecute, context.SourceEvent, context.Workflow));

            // Les actions specifiques à l'event a executer sur l'état courant avant de sortir
            foreach (ActionReferenceModel toExecute in _switch.ToExecutes)
                if ((toExecute.Way & OnEventEnum.OnExit) == OnEventEnum.OnExit)
                    actionResults.Add(toExecute.Reference.PushAction(toExecute, context.SourceEvent, context.Workflow));

            // Les actions de l'état a executer avant de sortir
            foreach (ActionReferenceModel toExecute in nextState.ToExecutes)
                if ((toExecute.Way & OnEventEnum.OnExit) == OnEventEnum.OnExit)
                    actionResults.Add(toExecute.Reference.PushAction(toExecute, context.SourceEvent, context.Workflow));

        }

        private WorkflowDefinitionModel _config;

    }

}
