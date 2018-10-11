using System;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// Describe an action to execute
    /// </summary>
    public class ActionDefinitionModel : DefinitionModel
    {

        public ActionDefinitionModel()
        {

        }

        public PushedAction PushAction(ActionReferenceModel reference, ISourceEvent @event, IWorkflowState state)
        {

            return new PushedAction
            {
                ActionName = this.Key,
                ActionComment = this.Comment,
                Arguments = reference.Arguments,
                Event = @event,
                Workflow = state,
            };

        }

        /// <summary>
        /// Pattern visitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitAction(this);
        }

    }

}
