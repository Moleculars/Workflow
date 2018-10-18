using System;

namespace Bb.Core
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

        public DateTime EventDate { get; set; }

        public DateTime PostDate { get; set; }

        /// <summary>
        /// The key that must matching with config event key
        /// </summary>
        public string Key { get; set; }

    }

}