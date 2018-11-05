using System;
using System.IO;

namespace Bb.Workflow.Configurations.Documents.Files
{


    public class LocalStorageConfigurationDocumentTemlate : MemoryConfigurationDocumentTemplate
    {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="file"></param>
        public LocalStorageConfigurationDocumentTemlate(FileInfo file)
        {
            _file = file;
            _length = _file.Directory.Parent.Parent.FullName.Length;
        }

        public override string Name => System.IO.Path.GetFileNameWithoutExtension(_file.Name);

        public override string Type => _file.Extension.Substring(1);

        public override DateTimeOffset CreationDate => _file.CreationTimeUtc;

        public override DateTimeOffset LastUpdate => _file.LastWriteTimeUtc;

        public override string Content => File.ReadAllText(_file.FullName);

        private FileInfo _file;
        private readonly int _length;

    }

}
