using Bb.Compilers.Pocos;
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
        public bool InitializeDefault(IConfigurationDocument document, CompileContext context)
        {

            //var result = new List<CheckResult>();
            //var repository = (PocoModelRepository)context.Repository;

            //try
            //{
            //    var sb = document.Content;
            //    MappingConfiguration[] models = MappingConfiguration.Load(sb);

            //    foreach (MappingConfiguration model in models)
            //    {
            //        if (model.Mappings.Count == 0)
            //        {

            //            PocoModel s = repository.Get(model.SourceType);
            //            PocoModel t = repository.Get(model.TargetType);


            //        }
            //    }

            //    return true;

            //}
            //catch (Exception ex)
            //{

            //    Trace.WriteLine(ex);

            //    result.Add(new CheckResult() { Document = document.Name, Message = ex.Message });

            //    if (System.Diagnostics.Debugger.IsAttached)
            //        System.Diagnostics.Debugger.Break();

            //}

            return false;

        }

        /// <summary>
        /// Checks the specified configuration embedded in configurationDocument.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<CheckResult> CheckPrecompilation(IConfigurationDocument document, CompileContext context)
        {

            var result = new List<CheckResult>();
            var repository = (PocoModelRepository)context.Repository;

            try
            {
                var sb = document.Content;
                MappingConfiguration[] models = MappingConfiguration.Load(sb);

                foreach (MappingConfiguration model in models)
                {
                    if (model.Mappings.Count == 0)
                    {

                        var s = repository.Get(model.SourceType);
                        var t = repository.Get(model.TargetType);

                        if (s == null)
                            result.Add(new CheckResult()
                            {
                                Document = document.Name,
                                Name = nameof(model.SourceType),
                                Message = "",
                                Severity = SeverityEnum.Error,
                                // LineNumber = document.LineNumber,
                                // LinePosition = document.LinePosition,
                            });

                        if (t == null)
                            result.Add(new CheckResult()
                            {
                                Document = document.Name,
                                Name = nameof(model.TargetType),
                                Message = "",
                                Severity = SeverityEnum.Error,
                                // LineNumber = document.LineNumber,
                                // LinePosition = document.LinePosition,
                            });

                    }
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
        public List<CheckResult> CheckPreCompilation(IEnumerable<IConfigurationDocument> documents, CompileContext context)
        {

            var result = new List<CheckResult>();

            foreach (var document in documents)
                result.AddRange(CheckPrecompilation(document, context));

            return result;

        }

        /// <summary>
        /// Compiles the specified documents.
        /// </summary>
        /// <param name="documents">The SBS.</param>
        public void InitializePreCompilation(IEnumerable<IConfigurationDocument> documents, CompileContext context)
        {

            var repository = (PocoModelRepository)context.Repository;
            var repositoryMappings = (MappingRepository)context.Repository;

            foreach (var item in documents)
            {

                var models = MappingConfiguration.Load(item.Content);

                foreach (var model in models)
                {

                    var s = repository.Get(model.SourceType);
                    var t = repository.Get(model.TargetType);

                    var types = repositoryMappings.ResolveTypes(model);

                    repositoryMappings.Append(model, item.Name, types.Item1, types.Item2);
                }

            }

        }

        public List<CheckResult> CheckPostCompilation(IConfigurationDocument document, CompileContext context)
        {
            var result = new List<CheckResult>();

            return result;

        }

        public List<CheckResult> CheckPostCompilation(IEnumerable<IConfigurationDocument> documents, CompileContext context)
        {
            var result = new List<CheckResult>();

            foreach (var document in documents)
                result.AddRange(CheckPostCompilation(document, context));

            return result;
        }
    }

}
