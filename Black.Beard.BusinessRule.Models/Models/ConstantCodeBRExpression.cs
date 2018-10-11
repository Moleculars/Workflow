using System.Linq.Expressions;

namespace Bb.BusinessRule.Models
{
    public class ConstantCodeBRExpression : CodeBRExpression
    {

        public object Value { get; set; }


        public override Expression Accept(IVisitor visitor)
        {
            return visitor.VisitConstant(this);
        }

    }

}