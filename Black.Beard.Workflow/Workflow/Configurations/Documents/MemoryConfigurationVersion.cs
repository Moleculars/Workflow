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
    public abstract class MemoryConfigurationVersion : IConfigurationVersion
    {

        public MemoryConfigurationVersion(IDomainConfiguration parent)
        {
            Parent = parent;
        }

        public string Name { get; set; }

        public bool IsDirty { get; set; }

        public DateTimeOffset LastUpdate { get; set; }

        public abstract IEnumerable<IConfigurationDocument> Documents { get; }

        public IDomainConfiguration Parent { get; }


        public abstract List<CheckResult> SaveFile(string typeName, string name, StringBuilder stringBuilder);

        /// <summary>
        /// Compiles the configuration in the specified path.
        /// </summary>
        /// <returns><see cref="Bb.Core.CompileResult"/></returns>
        /// <exception cref="NotImplementedException">compiler {type.Name}</exception>
        public ConfigurationCompileResult Compile()
        {

            ConfigurationCompiler compiler = new ConfigurationCompiler(this.Parent.Name, this.Name, this.Documents.ToList(), Parent.Parent.Types);
            return compiler.Compile();


            //var configurationCompileResult = new ConfigurationCompileResult()
            //{
            //    Domain = Parent.Name,
            //    Version = this.Name,
            //};

            //PocoModelRepository repository = new PocoModelRepository(configurationCompileResult.Domain);
            //repository.AddUsings(typeof(ISourceEvent), typeof(ExposeIncomingMessage));      // Add using & references for incomingModel
            //repository.AddUsings(typeof(Models.WorkflowModel), typeof(IWorkflowState));     // Add using & references for workflow state model
            
            //CompileContext ctx = new CompileContext(configurationCompileResult.Domain, Name)
            //{
            //    Repository = repository,
            //};

            //var documents = Documents.ToLookup(c => c.TypeConfiguration.Extension);
            //var types = Parent.Parent.Types;
            //foreach (var type in types)
            //{

            //    var items = documents[type.Extension];

            //    if (items.Any())
            //    {
            //        if (type.Compiler == null)
            //        {
            //            System.Diagnostics.Debugger.Break();
            //            throw new NotImplementedException($"compiler {type.Name} not implemented");
            //        }

            //        type.Compiler.PrepareCompile(items, ctx);

            //    }
            //}

            //string path = new FileInfo(typeof(PocoModelRepository).Assembly.Location).Directory.FullName;
            //string fullname = Path.Combine(path, repository.Filename) + ".dll";

            //configurationCompileResult.AssemblyCompiler = repository.Generate(path);

            //return configurationCompileResult;

        }

        public abstract IConfigurationDocument GetFile(string type, string name);

    }



}
