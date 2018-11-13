
using Newtonsoft.Json;
using System;

namespace Bb.Compilers.Models
{
    public class CompilerModelConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CompilerModel) || objectType == typeof(CompilerModelRoot);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            var instance = objectType == typeof(CompilerModelRoot)
                ? new CompilerModelRoot()
                : new CompilerModel()
                ;

            var r = reader as JsonTextReader;

            instance.LineNumber = r.LineNumber;
            instance.LinePosition = r.LinePosition;

            serializer.Populate(reader, instance);

            return instance;

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }

}


