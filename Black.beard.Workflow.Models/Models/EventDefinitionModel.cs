using System;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// Event definition model
    /// </summary>
    public class EventDefinitionModel : DefinitionModel
    {

        /// <summary>
        /// Pattern visitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitEvent(this);
        }

    }

}
