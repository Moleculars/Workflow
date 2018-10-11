using System.Linq.Expressions;

namespace Bb.BusinessRule.Models
{

    public abstract class CodeBRExpression
    {

        public abstract Expression Accept(IVisitor visitor);


    }

}