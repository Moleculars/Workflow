using Newtonsoft.Json;
using System;

namespace Bb.Mappings.Models
{
    public class MappingConfigurationConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MappingConfiguration);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            var r = reader as JsonTextReader;
            var instance = new MappingConfiguration()
            {
                LineNumber = r.LineNumber,
                LinePosition = r.LinePosition,
            };

            serializer.Populate(reader, instance);

            return instance;

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }

}
