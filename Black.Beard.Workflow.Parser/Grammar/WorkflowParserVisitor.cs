//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from WorkflowParser.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Bb.Workflow.Parser {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="WorkflowParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface IWorkflowParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.script"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScript([NotNull] WorkflowParser.ScriptContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.matchings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMatchings([NotNull] WorkflowParser.MatchingsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.matching"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMatching([NotNull] WorkflowParser.MatchingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.unit_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnit_statement([NotNull] WorkflowParser.Unit_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.define_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefine_statement([NotNull] WorkflowParser.Define_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstant([NotNull] WorkflowParser.ConstantContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] WorkflowParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.sequence_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSequence_statement([NotNull] WorkflowParser.Sequence_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.state"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitState([NotNull] WorkflowParser.StateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.on_event_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOn_event_statement([NotNull] WorkflowParser.On_event_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.delay"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDelay([NotNull] WorkflowParser.DelayContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.switch_state"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitch_state([NotNull] WorkflowParser.Switch_stateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.execute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExecute([NotNull] WorkflowParser.ExecuteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.execute2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExecute2([NotNull] WorkflowParser.Execute2Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.actions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitActions([NotNull] WorkflowParser.ActionsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.action"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAction([NotNull] WorkflowParser.ActionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.arguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArguments([NotNull] WorkflowParser.ArgumentsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.rule_condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_condition([NotNull] WorkflowParser.Rule_conditionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.action_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAction_statement([NotNull] WorkflowParser.Action_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.rule_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_statement([NotNull] WorkflowParser.Rule_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.event_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEvent_statement([NotNull] WorkflowParser.Event_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] WorkflowParser.NumberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.key"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKey([NotNull] WorkflowParser.KeyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.comment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComment([NotNull] WorkflowParser.CommentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.numeric"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumeric([NotNull] WorkflowParser.NumericContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.numbers"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumbers([NotNull] WorkflowParser.NumbersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WorkflowParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString([NotNull] WorkflowParser.StringContext context);
}
} // namespace Pssa.Workflow.Parser