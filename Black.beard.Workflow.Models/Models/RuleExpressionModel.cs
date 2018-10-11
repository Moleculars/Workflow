using System.Text;

namespace Bb.Workflow.Models
{
    /// <summary>
    /// Reference to rule by name
    /// </summary>
    public class RuleExpressionModel : ExpressionModel
    {

        /// <summary>
        /// Reference rule name
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Refenrece at the rule definition
        /// </summary>
        public RuleDefinitionModel Reference { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Key);

            return sb.ToString();
        }

        /// <summary>
        /// Pattern visitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitRuleExpression(this);
        }


    }

}