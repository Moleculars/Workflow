using Bb.Core;
using Bb.Workflow.Models;
using System;
using System.Collections.Generic;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// Workflow model base.
    /// </summary>
    public class WorkflowModel : IWorkflowState
    {

        public WorkflowModel()
        {
            this.Events = new List<StateEvent>();
        }

        /// <summary>
        /// Unique key workflow
        /// </summary>
        public Guid Uid { get; set; }

        /// <summary>
        /// Friendly name of the workflow
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// External key associated to workflow. assigned from event external key value
        /// </summary>
        public string ExternalKey { get; set; }

        public string CurrentStateKey
        {
            get
            {
                return _cCurrentStateKey;
            }
            set
            {
                _cCurrentStateKey = value;
                if (this.Events.Count > 0)
                    this.Events[this.Events.Count - 1].ToWorkflowSState = value;
            }
        }
        
        public uint ProcessorCrc { get; set; }

        /// <summary>
        /// List of events appended
        /// </summary>
        public List<StateEvent> Events { get; set; }

        /// <summary>
        /// Ne pas serializer
        /// </summary>
        //[JSonIgnore]
        public object WorkflowInstance { get; set; }

        private string _cCurrentStateKey;

    }

}