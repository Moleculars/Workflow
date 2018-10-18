using Bb.Core;
using System.Collections.Generic;

namespace Bb.Workflow.Models
{
    public interface IWorkflowContext
    {

        /// <summary>
        /// instance of the workflow
        /// </summary>
        IWorkflowState Workflow { get; set; }

        /// <summary>
        /// event source
        /// </summary>
        ISourceEvent SourceEvent { get; set; }

        /// <summary>
        /// List of actions must be pushed in the output
        /// </summary>
        List<PushedAction> ActionToExecutes { get; }

    }

}
