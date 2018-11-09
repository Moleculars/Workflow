
using Newtonsoft.Json;
using System;
using System.Text;

namespace Bb.Compilers.Models
{

    public class CompilerModelRoot : CompilerModel
    {

        public CompilerModelRoot()
        {
            Models = new CompilerModels();
        }

        /// <summary>
        /// Gets or sets the key of the model's cluster.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the model's list.
        /// </summary>
        /// <value>
        /// The models.
        /// </value>
        public CompilerModels Models { get; set; }

        public override object Accept(CompilerBaseVisitor visitor)
        {
            return visitor.Visit(this);
        }

        /// <summary>
        /// Deserializes the payload in <see cref="Bb.Compilers.Models.CompilerModelRoot"/>.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns></returns>
        public static CompilerModelRoot Load(StringBuilder sb)
        {
            return JsonConvert.DeserializeObject<CompilerModelRoot>(sb.ToString()

                , new PropertyConverter()
                , new ModelConverter()

                );
        }

    }

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

    public class ModelConverter : JsonConverter
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


