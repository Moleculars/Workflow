using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// Event tracing base used for containt the incoming message
    /// </summary>
    public class SourceEventTracing : ISourceEvent
    {

        /// <summary>
        /// Unique key of the event
        /// </summary>
        public Guid Uid { get; set; }

        /// <summary>
        /// Fonctionnal key of the object contained in the event
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the event
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Date of the post
        /// </summary>
        public DateTime PostDate { get; set; }

        /// <summary>
        /// Date of the event
        /// </summary>
        public DateTime EventDate { get; set; }

        public JObject Object { get; set; }

    }


    public class SourceEventTracingTypeConverter : System.ComponentModel.TypeConverter
    {

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            var result = base.CanConvertTo(context, destinationType);
            return true;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }

    }

    public class SourceEventTracingConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SourceEventTracing);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            var txt = JObject.Parse((string)existingValue);

            throw new NotImplementedException();

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }

}
