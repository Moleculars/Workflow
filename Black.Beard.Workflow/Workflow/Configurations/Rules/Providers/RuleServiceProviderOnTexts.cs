using Bb.BusinessRule.Parser;
using Bb.Workflow.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.Workflow.Configurations.Rules.Providers
{

    /// <summary>
    /// Implementation of Workflow service with storage of items in a folder
    /// </summary>
    /// <typeparam name="TSourceEvent"></typeparam>
    public class RuleServiceProviderOnTexts<TSourceEvent, TContext> : RuleServiceProviderLoader<TSourceEvent, TContext> 
        where TSourceEvent : ISourceEvent
        where TContext : IWorkflowContext
    {

        public RuleServiceProviderOnTexts(Func<string[]> items) : base()
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

        public override string Source => "delegate"; 

        /// <summary>
        /// Liste les configs
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<StringBuilder> GetContents()
        {

            foreach (var item in _contents)
                yield return item;

        }
        
        private readonly List<StringBuilder> _contents;
    }

}
