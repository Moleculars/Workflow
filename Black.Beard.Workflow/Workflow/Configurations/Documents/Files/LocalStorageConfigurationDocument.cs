using Bb.Core.Documents;
using Bb.Core.Helpers;
using System;
using System.Diagnostics;
using System.IO;

namespace Bb.Workflow.Configurations.Documents.Files
{
    public class LocalStorageConfigurationDocument : MemoryConfigurationDocument
    {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="file"></param>
        public LocalStorageConfigurationDocument(FileInfo file, IConfigurationVersion parent)
            : base(Path.GetFileNameWithoutExtension(file.Name),
                   parent,
                   parent.Parent.Parent.Types.GetByExtension(file.Extension.Substring(1))
                  )
        {

            _file = file;
            _length = _file.Directory.Parent.Parent.FullName.Length;
        }

        public override bool Rename(string newName)
        {

            try
            {
                var newPath = Path.Combine(_file.FullName, newName) + TypeConfiguration.Extension;
                _file.MoveTo(newPath);
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(new { Message = $"Failed to rename {_file.FullName}", Exception = ex });
            }

            return false;

        }

        public override bool Delete()
        {

            try
            {

                if (_file.Exists)
                {
                    DateTimeOffset time = LocalClock.GetNow;
                    string filename2 = _file.FullName + ".bck";
                    _file.MoveTo(filename2);
                    return true;
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(new { Message = $"Failed to rename the configuration {_file.FullName}", Exception = ex });
            }

            return false;

        }

        private static string GetValue(int time)
        {
            return time.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        public override void Save()
        {

            var filename = _file.FullName;

            if (_file.Exists)
            {
                DateTimeOffset time = LocalClock.GetNow;
                string _time = $"{time.Year}_{GetValue(time.Month)}_{GetValue(time.Day)}_{GetValue(time.Hour)}_{GetValue(time.Minute)}_{GetValue(time.Second)}_{GetValue(time.Day)}_{GetValue(time.Millisecond)}";
                string filename2 = Path.Combine(_file.Directory.FullName, $"{Name}_{_time}.{TypeConfiguration.Extension}.bck");
                _file.MoveTo(filename2);
                _file = new FileInfo(filename);
            }

            File.AppendAllText(filename, Content.ToString());

        }

        protected override void _loader(MemoryConfigurationDocument memoryConfigurationDocument)
        {
            _file.Refresh();
            CreationDate = new DateTimeOffset(_file.CreationTime);
            LastUpdate = new DateTimeOffset(_file.LastWriteTime);
            Content = new System.Text.StringBuilder(File.ReadAllText(_file.FullName));
        }

        private FileInfo _file;
        private readonly int _length;
        private static readonly Action<IConfigurationDocument> loader;


    }

}
