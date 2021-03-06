﻿using Bb.Compilers.Models;
using Bb.Compilers.Pocos;
using Bb.Core;
using Bb.Core.Documents;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bb.Workflow.Configurations
{

    public class StateMessageCompiler : IConfigurationDocumentCompiler
    {

        /// <summary>
        /// Checks the specified configuration embedded in configurationDocument.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<CheckResult> CheckPrecompilation(IConfigurationDocument document, CompileContext context)
        {

            var result = new List<CheckResult>();

            try
            {
                var sb = document.Content;
                var model = CompilerModelRoot.Load(sb);

                StateCompilerValidator validator = new StateCompilerValidator();
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
                        Severity = SeverityEnum.Error
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

            foreach (var item in documents)
            {

                var obj = CompilerModelRoot.Load(item.Content);

                var visitor = new StateCompilerVisitor(repository, context.Domain, context.Version);
                var result = visitor.Visit(obj);

                context.StateModels.Add(obj.Name);

            }

        }

        public bool InitializeDefault(IConfigurationDocument file, CompileContext context)
        {
            return false;
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
