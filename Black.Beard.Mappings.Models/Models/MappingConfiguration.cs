using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Mappings.Models
{

    public class MappingConfiguration
    {

        public MappingConfiguration()
        {
            this.Mappings = new List<MappingItemConfiguration>();
        }

        public string SourceType { get; set; }

        public string TargetType { get; set; }

        public List<MappingItemConfiguration> Mappings { get; set; }

          /// <summary>
        /// Deserializes the payload in <see cref="Bb.Mappings.Models.MappingConfiguration"/>.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns></returns>
        public static MappingConfiguration Load(StringBuilder sb)
        {
            return JsonConvert.DeserializeObject<MappingConfiguration>(sb.ToString()
                //, new ModelConverter()
                );

        }

    }

    //public class ModelConverter : JsonConverter
    //{

    //    public override bool CanConvert(Type objectType)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();

    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //}

}
