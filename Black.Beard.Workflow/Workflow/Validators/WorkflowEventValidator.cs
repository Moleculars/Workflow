using Bb.Core;
using Bb.Workflow.Configurations;
using Bb.Workflow.Models;
using System;

namespace Bb.Workflow.Validators
{

    public class WorkflowEventValidator<TEvent, TContext> : EventValidator<TEvent> 
        where TEvent : ISourceEvent
        where TContext : IWorkflowContext
    {

        private readonly WorkflowService<TEvent, TContext> _workflow;

        public WorkflowEventValidator(WorkflowService<TEvent, TContext> workflow, EventValidator<TEvent> child = null) : base(child)
        {
            this._workflow = workflow;
        }

        protected override void Validate_Impl(TEvent @event)
        {
            ProcessorWorkflow<TContext> wk = this._workflow.GetWorkflow(@event);
            if (!wk.Events.ContainsKey(@event.Key))
                throw new Exception($"invalid event {@event.Key}");
        }

    }


}
