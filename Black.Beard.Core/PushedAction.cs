using Bb.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bb.Core
{

    public class PushedAction
    {
        private static readonly JsonSerializerSettings _settings;

        public string ActionName { get; set; }

        public string ActionComment { get; set; }

        public List<string> Arguments { get; set; }

        public ISourceEvent Event { get; set; }

        public IWorkflowState Workflow { get; set; }

        public override string ToString()
        {
            return ActionComment.ToString();
        }

        static PushedAction()
        {
            PushedAction._settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                ConstructorHandling = ConstructorHandling.Default,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
            };

        }

        public static PushedAction Load(string payload)
        {
            PushedAction item = JsonConvert.DeserializeObject<PushedAction>(payload, PushedAction._settings);
            return item;
        }

        public string Save()
        {
            string json = JsonConvert.SerializeObject(this, PushedAction._settings);
            return json;
        }


    }

}
