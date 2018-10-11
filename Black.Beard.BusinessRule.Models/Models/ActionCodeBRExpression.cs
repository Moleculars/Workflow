using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.BusinessRule.Models
{
    public class ActionCodeBRExpression : CodeBRExpression
    {

        public ActionCodeBRExpression()
        {
            Arguments = new List<CodeBRExpression>();
        }

        public string Name { get; set; }

        public List<CodeBRExpression> Arguments { get; set; }

        public override Expression Accept(IVisitor visitor)
        {
            return visitor.VisitAction(this);
        }

    }

}
