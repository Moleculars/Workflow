using Bb.Workflow.Configurations;
using Bb.Workflow.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Workflow.Providers
{

    /// <summary>
    /// Implementation of Workflow service with storage of items in a folder
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public class WorkflowServiceProviderOnTexts<TEvent, TContext> : WorkflowService<TEvent, TContext> 
        where TEvent : ISourceEvent
        where TContext : IWorkflowContext

    {

        public WorkflowServiceProviderOnTexts(Func<string[]> items) : base()
        {

            this._contents = new List<StringBuilder>();

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            var datas = items();
            if (datas == null)
                throw new ArgumentNullException("function return null datas");

            foreach (var item in datas)
            {

                if (string.IsNullOrEmpty(item))
                    throw new ArgumentNullException("function return item data null");

                this._contents.Add(new StringBuilder(item));

            }

        }

        protected override IEnumerable<StringBuilder> GetContents()
        {

            foreach (var item in _contents)
                yield return item;

        }

        private readonly List<StringBuilder> _contents;

    }

}
