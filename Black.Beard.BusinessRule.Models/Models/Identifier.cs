using System;
using System.Linq.Expressions;
using System.Text;

namespace Bb.BusinessRule.Models
{

    public class Identifier : CodeBRExpression
    {

        public string Name { get; set; }

        public CodeBRExpression Sub { get; set; }

        public override Expression Accept(IVisitor visitor)
        {
            return visitor.VisitIdentifier(this);
        }

    }

}
