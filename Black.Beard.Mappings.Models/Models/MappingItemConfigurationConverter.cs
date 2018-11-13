using Newtonsoft.Json;
using System;

namespace Bb.Mappings.Models
{
    /// <summary>
    /// deserialize MappingItemConfiguration with line position in docuement
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    public class MappingItemConfigurationConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MappingItemConfiguration);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            var r = reader as JsonTextReader;
            var instance = new MappingItemConfiguration()
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