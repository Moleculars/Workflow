using Bb.Core.Documents;
using Bb.Workflow.Configurations.Documents;
using System;
using System.Collections.Generic;
using System.IO;
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
                foreach (var item in Folder.GetFiles())
                    if (!item.Extension.EndsWith(".bck"))
                        yield return new LocalStorageConfigurationDocument(item, this);
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

        public override List<CheckResult> SaveFile(string typeName, string name, StringBuilder stringBuilder)
        {

            var file = GetFile(typeName, name, stringBuilder);
            var results = file.TypeConfiguration.Compiler.Check(file);

            if (results.Count == 0)
            {
                file.Save();
                IsDirty = true;
            }

            return results;

        }

        public override IConfigurationDocument GetFile(string type, string name)
        {

            var _type = Parent.Parent.Types.GetByName(type);

            string pattern = $"{name}.{_type.Extension}";
            foreach (var item in Folder.GetFiles(pattern))
                return new LocalStorageConfigurationDocument(item, this);

            return null;

        }


    }

}
