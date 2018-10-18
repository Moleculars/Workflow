using Bb.BusinessRule.Parser;
using Bb.Core;
using Bb.Workflow.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.Workflow.Configurations.Rules.Providers
{

    /// <summary>
    /// Implementation of Workflow service with storage of items in a folder
    /// </summary>
    /// <typeparam name="TSourceEvent"></typeparam>
    public class RuleServiceProviderOnFiles<TSourceEvent, TContext> : RuleServiceProviderLoader<TSourceEvent, TContext> 
        where TSourceEvent : ISourceEvent
        where TContext : IWorkflowContext
    {

        public RuleServiceProviderOnFiles(string root) : base()
        {

            this._root = new DirectoryInfo(root);
            
            if (!this._root.Exists)
                throw new DirectoryNotFoundException($"directory {this._root.FullName} don't exist");

        }

        public override string Source => this._root.FullName; 

        /// <summary>
        /// Liste les fichiers *.rules du répertoire (_root)
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<StringBuilder> GetContents()
        {

            var files = _root.GetFiles("*.rules");

            foreach (var item in files)
            {
                var content = new StringBuilder(BusinessRuleContentHelper.LoadContentFromFile(item.FullName));
                yield return content;
            }

        }
        
        private DirectoryInfo _root;

    }

}
