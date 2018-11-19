using Bb.Compilers.Pocos;
using Bb.ComponentModel.Attributes;
using Bb.Core;
using Bb.Core.Documents;
using Bb.Mappings.Models;
using Black.Beard.Core.Documents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Bb.Workflow.Configurations.Documents
{

    internal class ConfigurationCompiler
    {

        public ConfigurationCompiler(VersionedConfigurationDocument rootConfig, TypeConfigurations types)
        {

            _types = types;
            _rootconfig = rootConfig;

            var documents = rootConfig.Documents.OrderBy(c => c.TypeConfiguration.CompileSort).ToList();
            _documents = documents.ToLookup(c => c.TypeConfiguration.Extension);

        }

        /// <summary>
        /// Compiles the configuration in the specified path.
        /// </summary>
        /// <returns><see cref="Bb.Core.CompileResult"/></returns>
        /// <exception cref="NotImplementedException">compiler {type.Name}</exception>
        public CompiledConfiguration Compile()
        {

            CompiledConfiguration compiledConfiguration = PrepareCompile();

            compiledConfiguration.Valid =

                InitializePreCompilation(compiledConfiguration, TypeConfiguration.PreCompileLimit) &&

                Compile(compiledConfiguration) &&

                PostCompile(compiledConfiguration) &&
                LogTrace(compiledConfiguration) &&

                CheckPostCompilation(compiledConfiguration)
                ;

            return compiledConfiguration;

        }

        private static bool LogTrace(CompiledConfiguration compiledConfiguration)
        {
            bool result = true;

            foreach (var item in compiledConfiguration.Diagnostics)
            {
                Trace.WriteLine(item.ToString());
                if (item.Severity == SeverityEnum.Error)
                    result = false;
            }
            return result;

        }

        /// <summary>
        /// Loop on files flaged PostCompile 
        /// </summary>
        /// <param name="configurationCompileResult"></param>
        /// <returns></returns>
        public bool PostCompile(CompiledConfiguration configurationCompileResult)
        {

            foreach (string assemblyName in _rootconfig.Assemblies)
            {
                var assembly = _rootconfig.TypeReferential.AddAssemblyFile(assemblyName);
                if (assembly != null)
                    _rootconfig.LoadedAssemblies.Add(assembly);
            }

            foreach (string assemblyName in _rootconfig.CompiledAssemblies)
            {
                var assembly = _rootconfig.TypeReferential.AddAssemblyFile(assemblyName);
                if (assembly != null)
                    _rootconfig.LoadedAssemblies.Add(assembly);
            }

            ILookup<string, IConfigurationDocument> documents = Documents();

            bool ok = true;

            foreach (var type in _types.OrderBy(c => c.CompileSort).Where(c => c.PostCompile))
            {

                var items = documents[type.Extension];

                if (items.Any())
                    if (!InitializePreCompilation(configurationCompileResult, Context, type, items)) // Ce n est pas une erreur. Il faut bien appeler InitializePreCompilation
                        ok = false;

            }

            return ok;
        }

        public bool CheckPostCompilation(CompiledConfiguration configurationCompileResult)
        {

            ILookup<string, IConfigurationDocument> documents = Documents();

            bool ok = true;

            foreach (var type in _types.OrderBy(c => c.CompileSort).Where(c => c.PostCompile))
            {

                var items = documents[type.Extension];

                if (items.Any())
                    if (!InitializePreCompilation(configurationCompileResult, Context, type, items))
                        ok = false;

            }

            return ok;
        }

        /// <summary>
        /// Collect of configuration's document
        /// </summary>
        /// <returns></returns>
        public ILookup<string, IConfigurationDocument> Documents()
        {
            return _documents;
        }

        public CompiledConfiguration PrepareCompile()
        {

            var configurationCompileResult = new CompiledConfiguration()
            {
                Domain = _rootconfig.Domain,
                Version = _rootconfig.Version,
            };

            var n = $"{configurationCompileResult.Domain}_{configurationCompileResult.Version}_{GetUniqueKey()}";

            while (File.Exists(Path.Combine(_rootconfig.PathRoot, n) + ".dll"))
                n = $"{configurationCompileResult.Domain}_{configurationCompileResult.Version}_{GetUniqueKey()}";

            repository = new PocoModelRepository(n);
            repository.AddUsings(typeof(ISourceEvent), typeof(ExposeModel));                // Add using & references for incomingModel
            repository.AddUsings(typeof(Models.WorkflowModel), typeof(IWorkflowState));     // Add using & references for workflow state model

            repositoryMapping = new MappingRepository(_rootconfig.TypeReferential);                             // Mapping builder & mapping repository

            Context = new CompileContext(_rootconfig.Domain, _rootconfig.Version, _rootconfig.TypeReferential)
            {
                VersionedConfiguration = _rootconfig,
                Repository = repository,
                RepositoryMapping = repositoryMapping,
            };

            return configurationCompileResult;

        }

        private string GetUniqueKey()
        {
            var n2 = Guid.NewGuid().ToString("N");
            return n2.Substring(0, 4).ToUpper();
        }

        public bool InitializePreCompilation(CompiledConfiguration configurationCompileResult, int precompileLimit)
        {

            ILookup<string, IConfigurationDocument> documents = Documents();
            bool ok = true;

            // go by type of document because the list is sorted by compileSort property
            foreach (var type in _types
                                    .OrderBy(c => c.CompileSort)
                                    .Where(c => c.CompileSort < precompileLimit))
            {

                var items = documents[type.Extension];

                if (items.Any())
                    if (!InitializePreCompilation(configurationCompileResult, Context, type, items))
                        ok = false;

            }

            return ok;

        }

        private static bool InitializePreCompilation(CompiledConfiguration configurationCompileResult, CompileContext ctx, TypeConfiguration type, IEnumerable<IConfigurationDocument> items)
        {

            bool ok = true;

            if (type.Compiler == null)
            {
                System.Diagnostics.Debugger.Break();
                throw new NotImplementedException($"compiler {type.Name} not implemented");
            }

            foreach (IConfigurationDocument doc in items)
            {
                var results = type.Compiler.CheckPrecompilation(doc, ctx);
                if (results.Any())
                {
                    ok = false;
                    configurationCompileResult.Diagnostics.AddRange(results);
                }
            }

            if (ok)
                type.Compiler.InitializePreCompilation(items, ctx);

            return ok;

        }

        public bool Compile(CompiledConfiguration configurationCompileResult)
        {

            AssemblyResult result = repository.Generate(_rootconfig.PathRoot);

            // translate compile error in checkResult for shown in website
            foreach (DiagnosticResult diag in result.Disgnostics)
                foreach (var item in diag.Locations)
                    configurationCompileResult.Diagnostics.Add(new CheckResult()
                    {
                        LineNumber = item.StartLine,
                        LinePosition = item.StartColumn,
                        Document = item.FilePath,
                        Message = diag.Message,
                        Severity = GetSeverity(diag.Severity),
                    });

            if (result.Success)
            {
                _rootconfig.CompiledAssemblies.Add(result.AssemblyFile);
                configurationCompileResult.AssemblyPath = result.AssemblyFile;
            }

            return result.Success;

        }

        private static SeverityEnum GetSeverity(string severity)
        {

            switch (severity)
            {

                case "Error":
                    return SeverityEnum.Error;

                default:
                    if (System.Diagnostics.Debugger.IsAttached)
                        System.Diagnostics.Debugger.Break();
                    Trace.WriteLine($"Failed to convert {severity} in {nameof(SeverityEnum)}");
                    break;

            }

            return SeverityEnum.Undefined;

        }

        public CompileContext Context { get; private set; }

        private readonly TypeConfigurations _types;
        private readonly VersionedConfigurationDocument _rootconfig;
        private readonly ILookup<string, IConfigurationDocument> _documents;
        private PocoModelRepository repository;
        private MappingRepository repositoryMapping;
    }

}
