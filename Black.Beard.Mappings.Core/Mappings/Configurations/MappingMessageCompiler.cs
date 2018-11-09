using Bb.Compilers.Models;
using Bb.Core;
using Bb.Core.Documents;
using Bb.Mappings.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bb.Mappings.Configurations
{

    public class MappingMessageCompiler : IConfigurationDocumentCompiler
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
                var model = CompilerModelRoot.Load(sb);

                MappingCompilerValidator validator = new MappingCompilerValidator();
                validator.Visit(model);

                foreach (var item in validator.Dignostics)
                {
                    result.Add(new CheckResult()
                    {
                        Document = document.Name,
                        Message = item.Message,
                        LineNumber = item.LineNumber,
                        LinePosition = item.LinePosition,
                        Name = item.Name,
                        Severity = "Error"
                    });

                }

            }
            catch (Exception ex)
            {

                Trace.WriteLine(ex);

                result.Add(new CheckResult() { Document = document.Name, Message = ex.Message });

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
        public void Initialize(IEnumerable<IConfigurationDocument> documents, CompileContext context)
        {

            var repositoryMappings = (MappingRepository)context.Repository;
            var typeResolver = context.TypeResolver;
            foreach (var item in documents)
            {

                var model = MappingConfiguration.Load(item.Content);

                Type source = typeResolver.ResolveByName(model.SourceType);
                Type target = typeResolver.ResolveByName(model.TargetType);

                repositoryMappings.Append(model, item.Name, source, target);

            }

        }

    }

}
