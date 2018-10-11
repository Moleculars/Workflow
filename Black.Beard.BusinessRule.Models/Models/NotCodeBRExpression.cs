using System.Linq.Expressions;

namespace Bb.BusinessRule.Models
{
    public class NotCodeBRExpression : CodeBRExpression
    {

        public NotCodeBRExpression()
        {

        }

        public CodeBRExpression Sub { get; set; }

        public override Expression Accept(IVisitor visitor)
        {
            return visitor.VisitNot(this);
        }

    }


}
