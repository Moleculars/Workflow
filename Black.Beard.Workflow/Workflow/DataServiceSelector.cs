using Bb.Workflow.Contracts;
using Bb.Workflow.Models;
using System;
using System.Collections.Generic;

namespace Bb.Workflow
{

    /// <summary>
    /// Data service selector, provide a service for determine the dataservice than manage storage for events.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TEvent"></typeparam>
    public abstract class DataServiceSelector<TState, TEvent>
         where TState : IWorkflowState
        where TEvent : ISourceEvent
    {

        public DataServiceSelector()
        {
            this._dic = new Dictionary<string, IDataService<TState, TEvent>>();
        }

        /// <summary>
        /// Append a new data service
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataService"></param>
        public void Append(string key, IDataService<TState, TEvent> dataService)
        {

            this._dic.Add(key, dataService);

        }

        /// <summary>
        /// return a specific data service for manage the store for the specified event 
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        internal IDataService<TState, TEvent> GetContextFor(ContextWorkflow<TState, TEvent> ctx)
        {

            if (this._dic.TryGetValue(ctx.SourceEvent.Key, out IDataService<TState, TEvent> result))
                return result;

            throw new NotImplementedException($"no context data can be resolved for {ctx.SourceEvent.Key}");

        }


        private readonly Dictionary<string, IDataService<TState, TEvent>> _dic;


    }

}
