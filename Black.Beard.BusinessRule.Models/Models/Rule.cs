using System.Linq.Expressions;

namespace Bb.BusinessRule.Models
{
    public class Rule
    {

        public RuleResultReturn Then { get; set; }

        public Rule Else { get; set; }

        public CodeBRExpression When { get; set; }

        public Expression Accept(IVisitor visitor)
        {
            return visitor.VisitRule(this);
        }

    }

}
