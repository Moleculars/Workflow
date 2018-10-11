using System.Linq.Expressions;

namespace Bb.BusinessRule.Models
{
    public class RuleResultReturn
    {

        public Identifier ObjectKind { get; set; }
        public Identifier ObjectName { get; set; }

        public Expression Accept(IVisitor visitor)
        {
            return visitor.VisitReturn(this);
        }

    }

}
