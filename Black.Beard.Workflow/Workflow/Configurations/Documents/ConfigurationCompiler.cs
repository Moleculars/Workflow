using Bb.Compilers.Pocos;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.Core;
using Bb.Core.Documents;
using Bb.Mappings.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Bb.Workflow.Configurations.Documents
{

    internal class ConfigurationCompiler
    {

        public ConfigurationCompiler(string domain, string version, IEnumerable<IConfigurationDocument> documents, TypeConfigurations types, TypeDiscovery typeDiscovery)
        {
            _domain = domain;
            _version = version;
            _documents = documents;
            _types = types;
            _typeDiscovery = typeDiscovery;

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

            MappingRepository repositoryMapping = new MappingRepository();                  // Mapping builder & mapping repository
            
            CompileContext ctx = new CompileContext(configurationCompileResult.Domain, _version)
            {
                Repository = repository,
                RepositoryMapping = repositoryMapping,
                TypeResolver = _typeDiscovery,
            };

            // Collect of configuration's document
            var documents = _documents.ToLookup(c => c.TypeConfiguration.Extension);

            #region Precompile

            // go by type of document because the list is sorted
            foreach (var type in _types.Where(c => !c.Precompile))
            {

                var items = documents[type.Extension];

                if (items.Any())
                    if (!Initialize(configurationCompileResult, ctx, type, items))
                        ok = false;

            }

            #endregion Precompile

            #region Compile

            if (ok)
            {

                string path = new FileInfo(typeof(PocoModelRepository).Assembly.Location).Directory.FullName;

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

                ok = r.Success;

                r.Load(); // Load compiled assembly 

            }

            #endregion Compile

            foreach (var item in configurationCompileResult.Diagnostics)
                Trace.WriteLine(item.ToString());

            #region Post compile

            if (ok)
            {

                foreach (var type in _types.Where(c => !c.Precompile))
                {

                    var items = documents[type.Extension];

                    if (items.Any())
                        if (!Initialize(configurationCompileResult, ctx, type, items))
                            ok = false;

                }

            }

            #endregion Post compile

            return configurationCompileResult;

        }

        private static bool Initialize(ConfigurationCompileResult configurationCompileResult, CompileContext ctx, TypeConfiguration type, IEnumerable<IConfigurationDocument> items)
        {

            bool ok = true;

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
                type.Compiler.Initialize(items, ctx);

            return ok;

        }

        private readonly string _domain;
        private readonly string _version;
        private readonly IEnumerable<IConfigurationDocument> _documents;
        private readonly TypeConfigurations _types;
        private readonly TypeDiscovery _typeDiscovery;
    }

}
