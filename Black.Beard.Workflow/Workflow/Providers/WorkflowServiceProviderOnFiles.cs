using Bb.Core;
using Bb.Workflow.Configurations;
using Bb.Workflow.Models;
using Bb.Workflow.Parser;
using Bb.Workflow.Parser.Grammar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Workflow.Providers
{

    /// <summary>
    /// Implementation of Workflow service with storage of items in a folder
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public class WorkflowServiceProviderOnFiles<TEvent, TContext> : WorkflowService<TEvent, TContext> 
        where TEvent : ISourceEvent
        where TContext : IWorkflowContext
    {

        public WorkflowServiceProviderOnFiles(string root) : base()
        {

            this._root = new DirectoryInfo(root);
            if (!this._root.Exists)
                throw new DirectoryNotFoundException($"directory {root} don't exist");

        }

        protected override IEnumerable<StringBuilder> GetContents()
        {

            var files = _root.GetFiles("*.workflow");

            foreach (var item in files)
            {
                var content = new StringBuilder(WorkflowContentHelper.LoadContentFromFile(item.FullName));
                yield return content;
            }

        }
        
        private DirectoryInfo _root;

    }

}
