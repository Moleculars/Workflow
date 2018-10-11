using System.Collections.Generic;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// Describe an event submit in the workflow
    /// </summary>
    public class OnEventReferenceModel : ReferenceModel
    {

        public OnEventReferenceModel()
        {
            Switchs = new List<SwitchDefinitionModel>();
        }

        /// <summary>
        /// the event is executed immediatly after the switch in the state
        /// </summary>
        public bool IsNoEvent { get; set; }


        public EventDefinitionModel EventReference { get; set; }

        /// <summary>
        /// delay in minute before execution
        /// </summary>
        public int Delay { get; set; }

        /// <summary>
        /// List of switchs to evaluate when an event is submited
        /// </summary>
        public List<SwitchDefinitionModel> Switchs { get; set; }

        /// <summary>
        /// Pattern visitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitOnEvent(this);
        }

    }

}
