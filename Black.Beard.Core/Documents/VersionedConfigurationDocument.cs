using Bb.ComponentModel;
using Bb.Core.Documents;
using Bb.Core.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Black.Beard.Core.Documents
{

    public class VersionedConfigurationDocument
    {

        public VersionedConfigurationDocument()
        {
            Assemblies = new HashSet<string>();
            CompiledAssemblies = new HashSet<string>();

            Documents = new List<IConfigurationDocument>();
            LoadedAssemblies = new HashSet<Assembly>();

        }


        #region Load/Save
    
        public void Save()
        {

            string path = _file.FullName;

            if (_file.Exists)
            {

                string name = Path.GetFileNameWithoutExtension(_file.Name);
                string extension = _file.Extension;

                DateTimeOffset time = Clock.GetNow;
                string _time = $"{time.Year}_{GetValue(time.Month)}_{GetValue(time.Day)}_{GetValue(time.Hour)}_{GetValue(time.Minute)}_{GetValue(time.Second)}_{GetValue(time.Day)}_{GetValue(time.Millisecond)}";
                string filename2 = Path.Combine(_file.Directory.FullName, $"{name}_{_time}.{extension}.bck");
                _file.MoveTo(filename2);
                _file = new FileInfo(path);

            }

            LastUpdate = Clock.GetNow;

            File.AppendAllText(path, Serialize().ToString());

        }

        public static VersionedConfigurationDocument Load(string path, string domain, string version, TypeReferential typeReferential)
        {

            VersionedConfigurationDocument instance = null;

            FileInfo _file = new FileInfo(path);
            _file.Refresh();

            if (_file.Exists)
            {
                var content = new System.Text.StringBuilder(File.ReadAllText(_file.FullName));
                instance = LoadFromContent(content, domain, version, path);
            }
            else
            {
                instance = new VersionedConfigurationDocument()
                {
                    CreationDate = Clock.GetNow,
                    Domain = domain,
                    Version = version,
                    LoadedAt = Clock.GetNow,
                    _file = _file,
                }
                ;
            }

            instance.TypeReferential = typeReferential;

            return instance;

        }

        public static VersionedConfigurationDocument LoadFromContent(StringBuilder content, string domain, string version, string file)
        {
            VersionedConfigurationDocument instance = JsonConvert.DeserializeObject<VersionedConfigurationDocument>(content.ToString());
            instance.Domain = domain;
            instance.Version = version;
            instance._file = new FileInfo(file);
            instance.LoadedAt = Clock.GetNow;

            if (instance.CreationDate == DateTimeOffset.MinValue)
                instance.CreationDate = new DateTimeOffset(instance._file.CreationTime);

            return instance;
        }

        public void Initialize(IConfigurationVersion configurationVersion, ITypeReferential typeReferential)
        {
            (Documents as List<IConfigurationDocument>).AddRange(configurationVersion.Documents);
            typeReferential.Initialize(this);
        }

        public StringBuilder Serialize()
        {
            StringBuilder content = new StringBuilder(JsonConvert.SerializeObject(this, Formatting.Indented));
            return content;
        }

        private static string GetValue(int time)
        {
            return time.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        #endregion Load/Save
        

        

        public HashSet<string> Assemblies { get; set; }

        public HashSet<string> CompiledAssemblies { get; set; }


        public DateTimeOffset CreationDate { get; set; }

        public DateTimeOffset LastUpdate { get; set; }

        public DateTimeOffset LoadedAt { get; private set; }

        public string Domain { get; private set; }

        public string Version { get; private set; }

        [JsonIgnore]
        public HashSet<Assembly> LoadedAssemblies { get; set; }

        [JsonIgnore]
        public IEnumerable<IConfigurationDocument> Documents { get; }

        [JsonIgnore]
        public TypeReferential TypeReferential { get; set; }

        [JsonIgnore]
        public string PathRoot { get; set; }

        private FileInfo _file;

    }

}
