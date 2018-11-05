using Bb.Compilers.Models;
using Bb.Compilers.Pocos;
using Bb.Core;
using Bb.Core.Documents;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bb.BusinessRule.Configurations
{

    public class IncomingMessageCompiler : IConfigurationDocumentCompiler
    {

        /// <summary>
        /// Checks the specified configuration embedded in configurationDocument.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<CheckResult> Check(IConfigurationDocument document)
        {

            var result = new List<CheckResult>();

            try
            {
                var sb = document.Content;
                CompilerModelRoot.Load(sb);
            }
            catch (Exception ex)
            {

                Trace.WriteLine(ex);

                result.Add(new CheckResult() { Document = document, Message = ex.Message });

                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();

            }

            return result;

        }

        /// <summary>
        /// Checks the specified configuration embedded in Stringbuilder.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns></returns>
        public List<CheckResult> Check(IEnumerable<IConfigurationDocument> documents)
        {

            var result = new List<CheckResult>();

            foreach (var document in documents)
                result.AddRange(Check(document));

            return result;

        }

        /// <summary>
        /// Compiles the specified documents.
        /// </summary>
        /// <param name="documents">The SBS.</param>
        public void PrepareCompile(IEnumerable<IConfigurationDocument> documents, CompileContext context)
        {

            var repository = (PocoModelRepository)context.Repository;

            foreach (var item in documents)
            {
                var obj = CompilerModelRoot.Load(item.Content);

                CompilerVisitor visitor = new CompilerVisitor(repository,context.Domain, context.Version);
                visitor.Visit(obj);
             
                context.IncomingModels.Add(obj.Name);
            }


        }


    }

}
