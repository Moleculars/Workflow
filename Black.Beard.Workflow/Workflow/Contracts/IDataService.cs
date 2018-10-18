using Bb.Core;
using Bb.Workflow.Models;
using System.Collections.Generic;

namespace Bb.Workflow.Contracts
{

    /// <summary>
    /// Used for interaction between memory and storage
    /// </summary>
    /// <typeparam name="TWorkflowState"></typeparam>
    /// <typeparam name="TSourceEvent"></typeparam>
    public interface IDataService<TWorkflowState, TSourceEvent> 
        where TWorkflowState : IWorkflowState
        where TSourceEvent : ISourceEvent
    {

        /// <summary>
        /// Return workflow's list for the specified externalId
        /// </summary>
        /// <param name="externalId"></param>
        /// <returns></returns>
        List<TWorkflowState> ReadItems(TSourceEvent @event);

        /// <summary>
        /// Create a new workflow model
        /// </summary>
        /// <param name="familyObject"></param>
        /// <param name="objectName"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        TWorkflowState Create(string familyObject, string objectName, TSourceEvent @event);

        /// <summary>
        /// Closing workflow.
        /// </summary>
        /// <param name="kindObject"></param>
        /// <param name="objectName"></param>
        /// <param name="state"></param>
        void Drop(string kindObject, string objectName, TWorkflowState state);

        /// <summary>
        /// Append a new event in the workflow
        /// </summary>
        /// <param name="event"></param>
        /// <param name="anomalie"></param>
        void AppendEvent(TSourceEvent @event, TWorkflowState anomalie);

        /// <summary>
        /// Store the workflow model
        /// </summary>
        /// <param name="state"></param>
        void Save(TWorkflowState state);


    }

}