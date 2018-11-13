
using Newtonsoft.Json;
using System;

namespace Bb.Compilers.Models
{
    public class PropertyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CompilerProperty);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            var r = reader as JsonTextReader;
            var instance = new CompilerProperty()
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


