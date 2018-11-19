using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Bb.Mappings.Models
{

    [System.Diagnostics.DebuggerDisplay("{SourceType} -> {TargetType}")]
    public class MappingConfiguration
    {

        internal int LineNumber;
        internal int LinePosition;

        public int GetLineNumber() => LineNumber;

        public int GetLinePosition() => LinePosition;

        public MappingConfiguration()
        {
            Mappings = new List<MappingItemConfiguration>();
        }
        
        public string SourceType { get; set; }

        public string TargetType { get; set; }

        public List<MappingItemConfiguration> Mappings { get; set; }

        /// <summary>
        /// Deserializes the payload in <see cref="Bb.Mappings.Models.MappingConfiguration"/>.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns></returns>
        public static MappingConfiguration[] Load(StringBuilder sb)
        {
            return JsonConvert.DeserializeObject<MappingConfiguration[]>(sb.ToString()
                , new MappingConfigurationConverter()
                , new MappingItemConfigurationConverter()
                , new PropertyPathConverter()
                );

        }

        /// <summary>
        /// Deserializes the payload in <see cref="Bb.Mappings.Models.MappingConfiguration"/>.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns></returns>
        public static StringBuilder Save(MappingConfiguration[] configurations)
        {
            StringBuilder sb = new StringBuilder(2000);
            sb.Append(JsonConvert.SerializeObject(configurations, Formatting.Indented));
            return sb;
        }

    }

}
