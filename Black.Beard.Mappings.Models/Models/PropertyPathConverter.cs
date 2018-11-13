using Newtonsoft.Json;
using System;

namespace Bb.Mappings.Models
{

    /// <summary>
    /// deserialize propertyPath with line position in docuement
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    public class PropertyPathConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PropertyPath);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            var r = reader as JsonTextReader;
            var instance = new PropertyPath()
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