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
        }

        public abstract IConfigurationDocument GetFile(string type, string name);

    }



}
