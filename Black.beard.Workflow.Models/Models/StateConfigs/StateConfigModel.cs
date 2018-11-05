namespace Bb.Workflow.Models.StateConfigs
{

    public class StateConfigModel
    {

        public StateConfigModel()
        {
            Models = new StateModels();
            Properties = new StateProperties();
        }

        public string Name { get; set; }

        public StateProperties Properties { get; set; }

        public string Description { get; set; }

        public StateModels Models { get; set; }
               
    }

}


