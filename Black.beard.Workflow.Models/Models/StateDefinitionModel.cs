using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// Describe a state
    /// </summary>
    public class StateDefinitionModel : DefinitionModel
    {

        private Dictionary<string, OnEventReferenceModel> _indexEvent;

        public StateDefinitionModel()
        {
            this.ToExecutes = new List<ActionReferenceModel>();
            this.Events = new List<OnEventReferenceModel>();
        }

        /// <summary>
        /// sequence name
        /// </summary>
        public string SequenceKey { get; set; }

        /// <summary>
        /// sequence description
        /// </summary>
        public string SequenceComment { get; set; }

        /// <summary>
        /// This state can't contains switch
        /// </summary>
        public bool IsFinal { get; set; }

        /// <summary>
        /// list of action to execute
        /// </summary>
        public List<ActionReferenceModel> ToExecutes { get; set; }

        /// <summary>
        /// List of exptected events
        /// </summary>
        public List<OnEventReferenceModel> Events { get; set; }
        public bool IsInitial { get; set; }

        /// <summary>
        /// Return the event by the specified key
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public OnEventReferenceModel ResolveEvent(string key)
        {

            if (this._indexEvent == null)
                this._indexEvent = this.Events.ToDictionary(c => c.Key);

            //Match the switch for event
            if (!this._indexEvent.TryGetValue(key, out OnEventReferenceModel resultEvent))
                // If not found, try to match for no event
                this._indexEvent.TryGetValue("[[NO EVENT]]", out resultEvent);

            return resultEvent;

        }

        /// <summary>
        /// Pattern visitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitState(this);
        }


    }


}
