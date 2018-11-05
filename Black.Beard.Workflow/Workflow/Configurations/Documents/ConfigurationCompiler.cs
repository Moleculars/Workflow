using Bb.Compilers.Pocos;
using Bb.ComponentModel.Attributes;
using Bb.Core;
using Bb.Core.Documents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Workflow.Configurations.Documents
{

    internal class ConfigurationCompiler
    {

        public ConfigurationCompiler(string domain, string version, IEnumerable<IConfigurationDocument>  documents, TypeConfigurations types)
        {
            this._domain = domain;
            this._version = version;
            this._documents = documents;
            this._types = types;
        }

        /// <summary>
        /// Compiles the configuration in the specified path.
        /// </summary>
        /// <returns><see cref="Bb.Core.CompileResult"/></returns>
        /// <exception cref="NotImplementedException">compiler {type.Name}</exception>
        public ConfigurationCompileResult Compile()
        {

            var configurationCompileResult = new ConfigurationCompileResult()
            {
                Domain = this._domain,
                Version = this._version,
            };

            PocoModelRepository repository = new PocoModelRepository(configurationCompileResult.Domain);
            repository.AddUsings(typeof(ISourceEvent), typeof(ExposeIncomingMessage));      // Add using & references for incomingModel
            repository.AddUsings(typeof(Models.WorkflowModel), typeof(IWorkflowState));     // Add using & references for workflow state model
            
            CompileContext ctx = new CompileContext(configurationCompileResult.Domain, this._version)
            {
                Repository = repository,
            };

            var documents = this._documents.ToLookup(c => c.TypeConfiguration.Extension);
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

                    type.Compiler.PrepareCompile(items, ctx);

                }
            }

            string path = new FileInfo(typeof(PocoModelRepository).Assembly.Location).Directory.FullName;
            string fullname = Path.Combine(path, repository.Filename) + ".dll";

            configurationCompileResult.AssemblyCompiler = repository.Generate(path);

            return configurationCompileResult;

        }

        private readonly string _domain;
        private readonly string _version;
        private readonly IEnumerable<IConfigurationDocument> _documents;
        private readonly TypeConfigurations _types;
    }

}
