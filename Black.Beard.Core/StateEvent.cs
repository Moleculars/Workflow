using System;

namespace Bb.Core
{
    public class StateEvent
    {

        public Guid Uid { get; set; }

        public DateTimeOffset IntegratedAt { get; set; }

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
        public DateTimeOffset TransitionChangedAt { get; set; }

        public DateTimeOffset EventDate { get; set; }

        public DateTimeOffset PostDate { get; set; }

        /// <summary>
        /// The key that must matching with config event key
        /// </summary>
        public string Key { get; set; }

    }

}