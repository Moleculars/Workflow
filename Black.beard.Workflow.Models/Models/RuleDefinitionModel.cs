namespace Bb.Workflow.Models
{


    /// <summary>
    /// Define a rule definition
    /// </summary>
    public class RuleDefinitionModel : DefinitionModel
    {
    
        /// <summary>
        /// Pattern visitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitRule(this);
        }

    }


}
