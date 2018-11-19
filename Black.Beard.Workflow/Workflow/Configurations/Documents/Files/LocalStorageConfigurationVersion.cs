using Bb.ComponentModel;
using Bb.Core.Documents;
using Black.Beard.Core.Documents;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Workflow.Configurations.Documents.Files
{


    public class LocalStorageConfigurationVersion : MemoryConfigurationVersion
    {

        public LocalStorageConfigurationVersion(IDomainConfiguration parent)
            : base(parent)
        {

        }

        public DirectoryInfo Folder { get; internal set; }

        public override IEnumerable<IConfigurationDocument> Documents
        {
            get
            {
                var types = Parent.Parent.Types;
                foreach (var item in Folder.GetFiles())
                {
                    var t = types.GetByExtension(item.Extension);
                    if (t != null)
                        yield return new LocalStorageConfigurationDocument(item, this, t);
                }

            }
        }

        private IConfigurationDocument GetFile(string type, string name, StringBuilder sb)
        {

            var _type = Parent.Parent.Types.GetByName(type);
            var filename = Path.Combine(Folder.FullName, $"{name}.{_type.Extension}");
            var item = new FileInfo(filename);

            return new LocalStorageConfigurationDocument(item, this)
            {
                Content = sb,
            };

        }

        public override List<CheckResult> SaveSubConfigurationDocument(string typeName, string name, StringBuilder stringBuilder)
        {

            List<CheckResult> results = null;
            IConfigurationDocument file = GetFile(typeName, name, stringBuilder);

            var root = LoadRootConfigurationDocument(_typeReferential);

            ConfigurationCompiler compiler = new ConfigurationCompiler(root, Parent.Parent.Types);
            CompiledConfiguration compiledConfiguration = compiler.PrepareCompile();

            bool ok = compiler.InitializePreCompilation(compiledConfiguration, file.TypeConfiguration.CompileSort);
            if (ok)
            {

                results = file.TypeConfiguration.Compiler.CheckPrecompilation(file, compiler.Context);

                if (!results.Any(c => c.Severity != SeverityEnum.Error))
                    if (file.TypeConfiguration.Compiler.InitializeDefault(file, compiler.Context))
                        results = file.TypeConfiguration.Compiler.CheckPrecompilation(file, compiler.Context);

                if (results.Count == 0)
                {
                    file.Save();
                    IsDirty = true;
                }

            }

            return results ?? new List<CheckResult>();

        }

        protected override VersionedConfigurationDocument LoadRootConfigurationDocument(TypeReferential typeReferential)
        {
            string filepath = Path.Combine(Folder.FullName, "root.json");
            var config = VersionedConfigurationDocument.Load(filepath, Parent.Name, Name, _typeReferential);

            config.PathRoot = Folder.FullName;
            config.Initialize(this, new CustomTypeReferential(typeReferential));
            return config;
        }

        public override IConfigurationDocument LoadSubConfigurationDocument(string typeName, string name)
        {

            var _type = Parent.Parent.Types.GetByName(typeName);

            string pattern = $"{name}.{_type.Extension}";
            foreach (var item in Folder.GetFiles(pattern))
                return new LocalStorageConfigurationDocument(item, this);

            return null;

        }


    }

}
