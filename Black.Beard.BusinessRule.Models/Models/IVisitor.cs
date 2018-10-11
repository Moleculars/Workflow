using System.Linq.Expressions;

namespace Bb.BusinessRule.Models
{
    public interface IVisitor
    {

        Expression VisitBinary(BinaryCodeBRExpression e);

        Expression VisitAction(ActionCodeBRExpression e);

        Expression VisitConstant(ConstantCodeBRExpression e);

        Expression VisitLoadData(LoadDataCodeBRExpression e);

        Expression VisitIdentifier(Identifier e);

        Expression VisitNot(NotCodeBRExpression e);

        Expression VisitRule(Rule e);

        Expression VisitReturn(RuleResultReturn e);

        Expression VisitRepository(RuleRepository ruleRepository);

    }
}