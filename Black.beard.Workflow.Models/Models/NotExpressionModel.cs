using System.Text;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// not expression
    /// </summary>
    public class NotExpressionModel : ExpressionModel
    {
        /// <summary>
        /// Expression to inverse result
        /// </summary>
        public ExpressionModel Expression { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"NOT {Expression.ToString()}");

            return sb.ToString();
        }

    }

}