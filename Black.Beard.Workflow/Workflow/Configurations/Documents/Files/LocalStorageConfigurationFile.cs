using System;
using System.IO;

namespace Bb.Workflow.Service.Configurations.Documents.Files
{
    public class LocalStorageConfigurationFile : IConfigurationFile
    {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="file"></param>
        public LocalStorageConfigurationFile(FileInfo file)
        {
            _file = file;
            _length = _file.Directory.Parent.Parent.FullName.Length;
        }

        public string Name => System.IO.Path.GetFileNameWithoutExtension(_file.Name);

        public string Type => _file.Extension.Substring(1);

        public DateTime CreationDate => _file.CreationTimeUtc;

        public DateTime LastUpdate => _file.LastWriteTimeUtc;

        public string[] Path => _file.FullName.Substring(_length).Split('/');

        private FileInfo _file;
        private readonly int _length;


    }

}
