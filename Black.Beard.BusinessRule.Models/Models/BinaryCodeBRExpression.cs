using System.Linq.Expressions;

namespace Bb.BusinessRule.Models
{
    public class BinaryCodeBRExpression : CodeBRExpression
    {

        public CodeBRExpression Left { get; set; }

        public OperatorsEnum Operator { get; set; }

        public CodeBRExpression Right { get; set; }

        public override Expression Accept(IVisitor visitor)
        {
            return visitor.VisitBinary(this);
        }

    }


}
