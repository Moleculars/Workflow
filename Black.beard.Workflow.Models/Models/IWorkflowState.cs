using System;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// Minimal attribute for workflows
    /// </summary>
    public interface IWorkflowState
    {

        /// <summary>
        /// The key that must matching with config state key
        /// </summary>
        string CurrentStateKey { get; set; }

        /// <summary>
        /// Unique key workflow
        /// </summary>
        Guid Uid { get; set; }

        /// <summary>
        /// Friendly name of the workflow
        /// </summary>
        string Kind { get; set; }

        /// <summary>
        /// External key associated to workflow. assigned from event external key value
        /// </summary>
        string ExternalKey { get; set; }

    }

}
