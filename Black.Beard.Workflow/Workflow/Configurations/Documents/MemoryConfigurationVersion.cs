using Bb.ComponentModel;
using Bb.Core.Documents;
using Black.Beard.Core.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Workflow.Configurations.Documents
{
    public abstract class MemoryConfigurationVersion : IConfigurationVersion
    {

        protected TypeReferential _typeReferential;

        public MemoryConfigurationVersion(IDomainConfiguration parent)
        {

            Parent = parent;


        }

        internal void Initialize(TypeReferential typeReferential)
        {
            _typeReferential = typeReferential;
        }

        public string Name { get; set; }

        public bool IsDirty { get; set; }

        public DateTimeOffset LastUpdate { get; set; }

        public abstract IEnumerable<IConfigurationDocument> Documents { get; }

        public IDomainConfiguration Parent { get; }

        public abstract List<CheckResult> SaveSubConfigurationDocument(string typeName, string name, StringBuilder stringBuilder);

        /// <summary>
        /// Compiles the configuration in the specified path.
        /// </summary>
        /// <returns><see cref="Bb.Core.CompileResult"/></returns>
        /// <exception cref="NotImplementedException">compiler {type.Name}</exception>
        public CompiledConfiguration Compile()
        {

            TypeReferential typeReferential = new TypeReferential();

            var documents = Documents.ToList();
            var config = LoadRootConfigurationDocument(typeReferential);

            config.CompiledAssemblies.Clear();

            ConfigurationCompiler compiler = new ConfigurationCompiler(config, Parent.Parent.Types);

            var result = compiler.Compile();

            if (result.Valid)
                SaveRootConfigurationDocument(config);

            return result;

        }

        protected abstract VersionedConfigurationDocument LoadRootConfigurationDocument(TypeReferential typeReferential);

        protected virtual void SaveRootConfigurationDocument(VersionedConfigurationDocument config)
        {
            config.Save();
        }

        public abstract IConfigurationDocument LoadSubConfigurationDocument(string type, string name);

    }



}
