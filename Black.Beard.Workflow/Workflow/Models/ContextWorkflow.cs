using Newtonsoft.Json;
using Bb.BusinessRule.Models;
using Bb.Core;
using Bb.Workflow.Models;
using System.Collections.Generic;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// Generic context for evaluation of one event incoming in the state machine
    /// </summary>
    /// <typeparam name="TSourceState"></typeparam>
    /// <typeparam name="TSourceEvent"></typeparam>
    public class ContextWorkflow<TSourceState, TSourceEvent> : IWorkflowContext, IRuleBusinessContext
        where TSourceState : IWorkflowState
        where TSourceEvent : ISourceEvent
    {

        /// <summary>
        /// Ctor
        /// </summary>
        public ContextWorkflow()
        {
            this.Datas = new Dictionary<string, object>();
            this.ActionToExecutes = new List<PushedAction>();
            this.EventResults = new List<ResultModel>();
        }

        /// <summary>
        /// List of actions must be to called
        /// </summary>
        public List<PushedAction> ActionToExecutes { get; }

        /// <summary>
        /// Event source
        /// </summary>
        public TSourceEvent SourceEvent { get; set; }

        /// <summary>
        /// Instance of the current workflow
        /// </summary>
        public TSourceState Workflow { get; set; }

        /// <summary>
        /// List of workflow's events
        /// </summary>
        public List<ResultModel> EventResults { get; }

        IWorkflowState IWorkflowContext.Workflow { get => this.Workflow; set => this.Workflow = (TSourceState)value; }

        ISourceEvent IWorkflowContext.SourceEvent { get => this.SourceEvent; set => this.SourceEvent = (TSourceEvent)value; }

        List<ResultModel> IRuleBusinessContext.EventResults => this.EventResults;

        /// <summary>
        /// Provider of services
        /// </summary>
        public ExtendedDataServiceProvider DataServices { get; internal set; }

        public Dictionary<string, object> Datas { get; set; }   // S serait bien de s en débarraser

        /// <summary>
        /// Crc of the business rule parameters
        /// </summary>
        public uint RuleCrc { get; internal set; }

    }


}
