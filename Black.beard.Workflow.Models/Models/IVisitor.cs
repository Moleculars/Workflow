namespace Bb.Workflow.Models
{
    public interface IVisitor<T>
    {
        T VisitReference(ReferenceModel m);
        T VisitWorkflow(WorkflowDefinitionModel m);
        T VisitSwitch(SwitchDefinitionModel m);
        T VisitState(StateDefinitionModel m);
        T VisitExpression(ExpressionModel m);
        T VisitRuleExpression(RuleExpressionModel m);
        T VisitRule(RuleDefinitionModel m);
        T VisitEvent(EventDefinitionModel m);
        T VisitOnEvent(OnEventReferenceModel m);
        T VisitDefinition(DefinitionModel m);
        T VisitAction(ActionDefinitionModel m);
        T VisitBinary(BinaryExpressionModel m);
        T ActionReference(ActionReferenceModel m);
    }
}