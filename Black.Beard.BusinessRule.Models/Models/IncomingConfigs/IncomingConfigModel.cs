namespace Bb.BusinessRule.Models.IncomingConfigs
{

    public class IncomingConfigModel
    {

        public IncomingConfigModel()
        {
            Models = new IncomingModels();
        }

        public string Key { get; set; }

        public string ModelName { get; set; }

        public string Description { get; set; }

        public IncomingModels Models { get; set; }
               
    }

}


