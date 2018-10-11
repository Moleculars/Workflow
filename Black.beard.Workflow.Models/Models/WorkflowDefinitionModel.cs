using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// Root cluster model that define configuration for a workflow process 
    /// </summary>
    public class WorkflowDefinitionModel : DefinitionModel
    {

        private Dictionary<string, StateDefinitionModel> _indexState;

        public WorkflowDefinitionModel()
        {
            this.States = new List<StateDefinitionModel>();
            this.Events = new List<EventDefinitionModel>();
            this.Rules = new List<RuleDefinitionModel>();
            this.Matchings = new List<List<KeyValuePair<string, string>>>();
            this.Errors = new List<ErrorModel>();
        }

        /// <summary>
        /// List of expected states
        /// </summary>
        public List<StateDefinitionModel> States { get; set; }

        public List<List<KeyValuePair<string, string>>> Matchings { get; set; }

        /// <summary>
        /// Return the state by the specified key
        /// </summary>
        /// <param name="stateKey"></param>
        /// <returns></returns>
        public StateDefinitionModel ResolveState(string stateKey)
        {

            if (this._indexState == null)
                this._indexState = this.States.ToDictionary(c => c.Key);

            StateDefinitionModel resultState;

            if (!this._indexState.TryGetValue(stateKey, out resultState))
                throw new EntryPointNotFoundException($"unexpected state {stateKey}");

            return resultState;

        }

        /// <summary>
        /// List of error. if the list is not empty, an exception is thrown in the workflow process
        /// </summary>
        public List<ErrorModel> Errors { get; set; }

        public uint Crc { get; set; }
        public List<EventDefinitionModel> Events { get; set; }
        public List<RuleDefinitionModel> Rules { get; set; }

        public override string ToString()
        {
            return $"{Key} -> '{Comment}'";
        }

        /// <summary>
        /// Pattern visitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitWorkflow(this);
        }

    }
}
