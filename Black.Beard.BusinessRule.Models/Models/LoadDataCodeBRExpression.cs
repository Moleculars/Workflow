using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.BusinessRule.Models
{

    public class LoadDataCodeBRExpression : ActionCodeBRExpression
    {

        public override Expression Accept(IVisitor visitor)
        {
            return visitor.VisitLoadData(this);
        }

    }

}