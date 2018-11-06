using Bb.Compilers.Pocos;
using Bb.ComponentModel.Attributes;
using Bb.Core;
using Bb.Core.Documents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Bb.Workflow.Configurations.Documents
{

    internal class ConfigurationCompiler
    {

        public ConfigurationCompiler(string domain, string version, IEnumerable<IConfigurationDocument> documents, TypeConfigurations types)
        {
            _domain = domain;
            _version = version;
            _documents = documents;
            _types = types;
        }

        /// <summary>
        /// Compiles the configuration in the specified path.
        /// </summary>
        /// <returns><see cref="Bb.Core.CompileResult"/></returns>
        /// <exception cref="NotImplementedException">compiler {type.Name}</exception>
        public ConfigurationCompileResult Compile()
        {

            bool ok = true;

            var configurationCompileResult = new ConfigurationCompileResult()
            {
                Domain = _domain,
                Version = _version,
            };

            PocoModelRepository repository = new PocoModelRepository(configurationCompileResult.Domain);
            repository.AddUsings(typeof(ISourceEvent), typeof(ExposeIncomingMessage));      // Add using & references for incomingModel
            repository.AddUsings(typeof(Models.WorkflowModel), typeof(IWorkflowState));     // Add using & references for workflow state model

            CompileContext ctx = new CompileContext(configurationCompileResult.Domain, _version)
            {
                Repository = repository,
            };

            var documents = _documents.ToLookup(c => c.TypeConfiguration.Extension);
            foreach (var type in _types)
            {

                var items = documents[type.Extension];

                if (items.Any())
                {
                    if (type.Compiler == null)
                    {
                        System.Diagnostics.Debugger.Break();
                        throw new NotImplementedException($"compiler {type.Name} not implemented");
                    }

                    foreach (IConfigurationDocument doc in items)
                    {
                        var results = type.Compiler.Check(doc);
                        if (results.Any())
                        {
                            ok = false;
                            configurationCompileResult.Diagnostics.AddRange(results);
                        }
                    }

                    if (ok)
                        type.Compiler.PrepareCompile(items, ctx);

                }
            }

            string path = new FileInfo(typeof(PocoModelRepository).Assembly.Location).Directory.FullName;
            string fullname = Path.Combine(path, repository.Filename) + ".dll";

            if (ok)
            {
                var r = repository.Generate(path);
                configurationCompileResult.AssemblyCompiler = r;

                // translate compile error in checkResult for shown in website
                foreach (DiagnosticResult diag in r.Disgnostics)
                    foreach (var item in diag.Locations)
                        configurationCompileResult.Diagnostics.Add(new CheckResult()
                        {
                            LineNumber = item.StartLine,
                            LinePosition = item.StartColumn,
                            Document = item.FilePath,
                            Message = diag.Message,
                            Severity = diag.Severity,
                        });


            }

            foreach (var item in configurationCompileResult.Diagnostics)
                Trace.WriteLine(item.ToString());

            return configurationCompileResult;

        }

        private readonly string _domain;
        private readonly string _version;
        private readonly IEnumerable<IConfigurationDocument> _documents;
        private readonly TypeConfigurations _types;

    }

}
