using System;

namespace Bb.Workflow.Models
{
    public class StateEvent
    {

        public Guid Uid { get; set; }

        public DateTime IntegratedAt { get; set; }

        /// <summary>
        /// Initiale state before integration of last event
        /// </summary>
        public string FromWorkflowState { get; set; }

        /// <summary>
        /// final state after integration of last event
        /// </summary>
        public string ToWorkflowSState { get; set; }

        /// <summary>
        /// date where the event is provided
        /// </summary>
        public DateTime TransitionChangedAt { get; set; }

        /// <summary>
        /// workflow processor crc
        /// </summary>
        public uint WorkflowProcessorCrc { get; set; }

        
        
        //public int LastParcelStatut { get; set; }

        //public int CurrentParcelStatut { get; set; }

    }

}