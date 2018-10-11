using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Bb.Workflow.Models;

namespace Bb.Workflow.Parser.Grammar
{

    public class ConfigConverterWorkflowVisitor : WorkflowParserBaseVisitor<object>, IFile
    {

        public ConfigConverterWorkflowVisitor()
        {
        }

        public string Filename { get; set; }

        public uint Crc { get; set; }

        public void EvaluateErrors(IParseTree item)
        {

            if (item != null)
            {

                if (item is ErrorNodeImpl e)
                    this._errors.Add(new ErrorModel() { Message = $"Failed to parse script at position {e.Symbol.StartIndex}, line {e.Symbol.Line}, col {e.Symbol.Column} ' {e.Symbol.Text}'" });

                int c = item.ChildCount;
                for (int i = 0; i < c; i++)
                {
                    IParseTree child = item.GetChild(i);
                    EvaluateErrors(child);
                }

            }

        }

        public IEnumerable<ErrorModel> Errors { get => this._errors; }

        public override object Visit(IParseTree tree)
        {
            this._errors = new List<ErrorModel>();
            EvaluateErrors(tree);

            return base.Visit(tree);

        }

        /// <summary>
        /// action : key LEFT_PAREN arguments? RIGHT_PAREN
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitAction([NotNull] WorkflowParser.ActionContext context)
        {

            var key = (string)VisitKey(context.key());
            var a = new ActionReferenceModel()
            {
                Key = key,
                Reference = Resolve<ActionDefinitionModel>(key),
            };

            var arguments = context.arguments();
            if (arguments != null)
            {
                var args = arguments.@string();
                if (args != null)
                    foreach (var item in args)
                    {
                        var arg = item.GetText();
                        a.Arguments.Add(arg.Substring(1, arg.Length - 2));
                    }
            }

            return a;

        }

        /// <summary>
        /// actions :
        ///    action (COMMA action)*
        /// ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitActions([NotNull] WorkflowParser.ActionsContext context)
        {

            List<ActionReferenceModel> actions = new List<ActionReferenceModel>();

            var _actions = context.action();
            foreach (var action in _actions)
                actions.Add((ActionReferenceModel)VisitAction(action));

            return actions;

        }

        /// <summary>
        /// action : LEFT_PAREN arguments? RIGHT_PAREN
        ///    key 
        /// ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitAction_statement([NotNull] WorkflowParser.Action_statementContext context)
        {
            var a = new ActionDefinitionModel()
            {
                Key = (string)VisitKey(context.key()),
                Comment = (string)VisitComment(context.comment()),
            };
            Append(a);
            return a;

        }

        /// <summary>
        /// arguments : 
        ///    string (COMMA string)*
        /// ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitArguments([NotNull] WorkflowParser.ArgumentsContext context)
        {
            Stop();
            return base.VisitArguments(context);
        }

        /// <summary>
        /// comment : CHAR_COMMENT;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitComment([NotNull] WorkflowParser.CommentContext context)
        {
            var result = context.CHAR_COMMENT().Symbol.Text;
            result = result.Substring(1, result.Length - 2);
            return result;
        }

        /// <summary>
        /// define_statement :
        ///    DEFINE
        ///    (
        ///        event_statement
        ///      | constante
        ///      | rule_statement
        ///      | action_statement
        ///      | sequence_statement
        ///    )
        ///    ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitDefine_statement([NotNull] WorkflowParser.Define_statementContext context)
        {
            return base.VisitDefine_statement(context);
        }

        public override object VisitConstant([NotNull] WorkflowParser.ConstantContext context)
        {
            return base.VisitConstant(context);
        }

        public override object VisitValue([NotNull] WorkflowParser.ValueContext context)
        {

            return base.VisitValue(context);

        }

        public override object VisitNumbers([NotNull] WorkflowParser.NumbersContext context)
        {

            var text = context.GetText();
            if (text.Contains("."))
            {
                text = text.Replace('.', ',');
                return decimal.Parse(text, CultureInfo.InvariantCulture);
            }

            var i = Int64.Parse(text, CultureInfo.InvariantCulture);

            if (i < Int32.MaxValue)
                return (Int32)i;

            return i;

        }

        /// <summary>
        /// delay : number(MINUTE | HOUR | DAY)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitDelay([NotNull] WorkflowParser.DelayContext context)
        {

            int result = int.Parse(context.number().NUMBER().Symbol.Text);

            if (context.HOUR() != null)
                result *= 60;

            else if (context.DAY() != null)
                result *= 60 * 24;

            return result;

        }

        public override object VisitErrorNode(IErrorNode node)
        {
            Stop();
            return base.VisitErrorNode(node);
        }

        /// <summary>
        /// event_statement : NO? EVENT key comment
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitEvent_statement([NotNull] WorkflowParser.Event_statementContext context)
        {
            var e = new EventDefinitionModel()
            {
                Key = (string)VisitKey(context.key()),
                Comment = (string)VisitComment(context.comment()),
            };
            Append(e);
            return e;
        }

        /// <summary>
        /// execute2 : (ON EXIT)? EXECUTE LEFT_PAREN actions? RIGHT_PAREN
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitExecute2([NotNull] WorkflowParser.Execute2Context context)
        {

            List<ActionReferenceModel> _actions = new List<ActionReferenceModel>();

            var actions = context.actions();
            if (actions != null)
                _actions = (List<ActionReferenceModel>)VisitActions(actions);

            foreach (var item in _actions)
            {
                if (context.EXIT() != null)
                    item.Way = OnEventEnum.OnExit;
                else
                    item.Way = OnEventEnum.OnEvent;
            }

            return _actions;

        }

        /// <summary>
        /// execute : ON(ENTER | EXIT | ENTER EXIT) EXECUTE LEFT_PAREN actions? RIGHT_PAREN
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitExecute([NotNull] WorkflowParser.ExecuteContext context)
        {

            List<ActionReferenceModel> _actions = new List<ActionReferenceModel>();

            var actions = context.actions();
            if (actions != null)
                _actions = (List<ActionReferenceModel>)VisitActions(actions);

            foreach (var item in _actions)
            {

                if (context.ENTER() != null)
                {
                    item.Way = OnEventEnum.OnEnter;
                    if (context.EXIT() != null)
                        item.Way = OnEventEnum.OnBoth;
                }
                else if (context.EXIT() != null)
                    item.Way = OnEventEnum.OnExit;

            }

            return _actions;

        }

        /// <summary>
        /// key : CHAR_STRING | REGULAR_ID;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitKey([NotNull] WorkflowParser.KeyContext context)
        {

            string result = string.Empty;

            var char_string = context.CHAR_STRING();
            if (char_string != null)
            {
                result = char_string.Symbol.Text;
                result = result.Trim().Trim('\'');
            }
            else
            {
                result = context.REGULAR_ID().Symbol.Text.Trim();
            }

            return result;

        }

        /// <summary>
        /// number : NUMBER;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitNumber([NotNull] WorkflowParser.NumberContext context)
        {
            Stop();
            return base.VisitNumber(context);
        }

        /// <summary>
        /// on_event_statement : (NO EVENT | ON EVENT key | AFTER delay) switch_state+
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitOn_event_statement([NotNull] WorkflowParser.On_event_statementContext context)
        {

            var e = new OnEventReferenceModel()
            {
                IsNoEvent = context.NO() != null,
            };

            if (context.ON() != null)
            {
                e.Key = (string)VisitKey(context.key());
                e.EventReference = Resolve<EventDefinitionModel>(e.Key);
            }
            else if (context.AFTER() != null)
            {
                e.Key = "[[DELAY]]";
                e.Delay = (int)VisitDelay(context.delay());
            }
            else
                e.Key = "[[NO EVENT]]";

            var switchs = context.switch_state();
            if (switchs != null)
                foreach (var @switch in switchs)
                    e.Switchs.Add((SwitchDefinitionModel)VisitSwitch_state(@switch));

            return e;

        }

        /// <summary>
        /// rule_condition :
        ///       key
        ///     | NOT rule_condition
        ///     | rule_condition AND rule_condition
        ///     | rule_condition OR rule_condition
        ///     | LEFT_PAREN rule_condition RIGHT_PAREN
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitRule_condition([NotNull] WorkflowParser.Rule_conditionContext context)
        {

            ExpressionModel result = null;
            var key = context.key();
            if (key != null)
            {
                result = new RuleExpressionModel()
                {
                    Key = (string)VisitKey(context.key()),
                };
                (result as RuleExpressionModel).Reference = Resolve<RuleDefinitionModel>((result as RuleExpressionModel).Key);

            }
            else if (context.NOT() != null)
            {
                result = new NotExpressionModel()
                {
                    Expression = (ExpressionModel)VisitRule_condition(context.rule_condition()[0])
                };
            }
            else if (context.AND() != null)
            {
                result = new BinaryExpressionModel()
                {
                    Left = (ExpressionModel)VisitRule_condition(context.rule_condition()[0]),
                    Operator = "AND",
                    Right = (ExpressionModel)VisitRule_condition(context.rule_condition()[1])
                };
            }
            else if (context.OR() != null)
            {
                result = new BinaryExpressionModel()
                {
                    Left = (ExpressionModel)VisitRule_condition(context.rule_condition()[0]),
                    Operator = "OR",
                    Right = (ExpressionModel)VisitRule_condition(context.rule_condition()[1])
                };
            }
            else if (context.LEFT_PAREN() != null && context.RIGHT_PAREN() != null)
            {
                result = (ExpressionModel)VisitRule_condition(context.rule_condition()[0]);
            }

            return result;

        }

        /// <summary>
        /// rule_statement : RULE key comment
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitRule_statement([NotNull] WorkflowParser.Rule_statementContext context)
        {

            var r = new RuleDefinitionModel()
            {
                Key = (string)VisitKey(context.key()),
                Comment = (string)VisitComment(context.comment()),
            };

            Append(r);

            return r;

        }

        /// <summary>
        /// script :
        ///     NAME key
        ///     (DESCRIPTION comment)?
        ///     (INCLUDE CHAR_STRING) *
        ///     (MATCHING matching*)?
        ///     (unit_statement SEMICOLON) * EOF
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitScript([NotNull] WorkflowParser.ScriptContext context)
        {

            this._initialSource = new StringBuilder(context.Start.InputStream.ToString());

            var workflow = new WorkflowDefinitionModel()
            {
                Key = (string)VisitKey(context.key()),
                Crc = this.Crc,
            };

            if (context.DESCRIPTION() != null)
                workflow.Comment = (string)VisitComment(context.comment());

            if (context.MATCHING() != null)
            {
                foreach (var matchings in context.matchings())
                    workflow.Matchings.Add((List<KeyValuePair<string, string>>)VisitMatchings(matchings));
            }

            var includes = context.CHAR_STRING();
            if (includes != null)
                foreach (var item in includes)
                {

                }

            var unit_statements = context.unit_statement();
            foreach (var unit_statement in unit_statements)
                VisitUnit_statement(unit_statement);

            workflow.Errors.AddRange(this._errors);

            foreach (var item in this._items)
            {
                if (item.Value is StateDefinitionModel s)
                {
                    workflow.States.Add(s);

                    foreach (var e in s.Events)
                    {

                        if (!(e.Key.StartsWith("[[") && e.Key.EndsWith("]]")))
                            e.EventReference = Resolve<EventDefinitionModel>(e.Key);
                    }
                }
                else if (item.Value is EventDefinitionModel e)
                    workflow.Events.Add(e);

                else if (item.Value is RuleDefinitionModel r)
                    workflow.Rules.Add(r);

                else if (item.Value is ActionDefinitionModel a)
                {

                }
                else
                {

                }
            }

            var count = workflow.States.Count(c => c.IsInitial);
            if (count < 1)
                throw new Exception($"workflow must to have one and only one initial state.");

            if (count > 1)
                throw new Exception($"workflow must to have one initial state.");

            count = workflow.States.Count(c => c.IsFinal);
            if (count < 1)
                throw new Exception($"workflow must to have one or more final state.");

            return workflow;

        }

        /// <summary>
        /// LEFT_PAREN matching RIGHT_PAREN (COMMA LEFT_PAREN matching RIGHT_PAREN)*
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitMatchings([NotNull] WorkflowParser.MatchingsContext context)
        {
            List<KeyValuePair<string, string>> _result = new List<KeyValuePair<string, string>>();
            foreach (var matching in context.matching())
                _result.Add((KeyValuePair<string, string>)VisitMatching(matching));
            return _result
                .OrderBy(c => c.Key + c.Value)
                .ToList();
        }

        /// <summary>
        /// matching : key EQUAL CHAR_STRING;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitMatching([NotNull] WorkflowParser.MatchingContext context)
        {
            var key = (string)VisitKey(context.key());
            var char_string = context.CHAR_STRING();
            var value = char_string.Symbol.Text.Trim().Trim('\'');
            return new KeyValuePair<string, string>(key, value);
        }

        private void Append(DefinitionModel item)
        {
            _items.Add(item.Key, item);
        }

        private T Resolve<T>(string key) where T : DefinitionModel
        {

            if (!this._items.TryGetValue(key, out DefinitionModel result))
                this._errors.Add(new ErrorModel() { Message = $"reference to key '{key}' can't be resolved" });

            return (T)result;

        }

        /// <summary>
        /// sequence_statement :
        ///     SEQUENCE key comment state+
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitSequence_statement([NotNull] WorkflowParser.Sequence_statementContext context)
        {

            var key = (string)VisitKey(context.key());
            var comment = (string)VisitComment(context.comment());

            var states = context.state();
            foreach (var state in states)
            {
                var s = (StateDefinitionModel)VisitState(state);
                s.SequenceKey = key;
                s.SequenceComment = key;
                Append(s);
            }

            return null;

        }

        /// <summary>
        /// state :
        ///     WITH (INITIAL | FINAL)? STATE key comment
        ///     execute*
        ///     on_event_statement*
        /// ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitState([NotNull] WorkflowParser.StateContext context)
        {

            var state = new StateDefinitionModel()
            {
                Key = (string)VisitKey(context.key()),
                Comment = (string)VisitComment(context.comment()),
                IsFinal = context.FINAL() != null,
                IsInitial = context.INITIAL() != null,
            };

            var executes = context.execute();
            if (executes != null)
                foreach (var execute in executes)
                    state.ToExecutes.AddRange((List<ActionReferenceModel>)VisitExecute(execute));

            var on_event_statements = context.on_event_statement();
            if (on_event_statements != null)
                foreach (var on_event_statement in on_event_statements)
                    state.Events.Add((OnEventReferenceModel)VisitOn_event_statement(on_event_statement));

            return state;

        }

        /// <summary>
        /// string : CHAR_STRING;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitString([NotNull] WorkflowParser.StringContext context)
        {
            Stop();
            return base.VisitString(context);
        }

        /// <summary>
        /// switch_state :
        ///       (WHEN rule_condition)? execute2* (WAITING delay BEFORE)? SWITCH key
        ///     | (WHEN rule_condition)? execute2+
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitSwitch_state([NotNull] WorkflowParser.Switch_stateContext context)
        {

            var key = context.key();
            var s = new SwitchDefinitionModel()
            {
            };

            if (key != null)
                s.Key = (string)VisitKey(key);

            if (context.WHEN() != null)
                s.When = (ExpressionModel)VisitRule_condition(context.rule_condition());

            var executes = context.execute2();
            if (executes != null)
                foreach (var execute in executes)
                    s.ToExecutes.AddRange((List<ActionReferenceModel>)VisitExecute2(execute));

            if (context.WAITING() != null)
                s.Delay = (int)VisitDelay(context.delay());

            return s;

        }

        /// <summary>
        /// unit_statement :
        ///       define_statement
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitUnit_statement([NotNull] WorkflowParser.Unit_statementContext context)
        {
            base.VisitUnit_statement(context);
            return null;
        }




        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        private void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

        private StringBuilder GetText(RuleContext context)
        {

            if (context is ParserRuleContext s)
                return GetText(s.Start.StartIndex, s.Stop.StopIndex + 1);
            return new StringBuilder();
        }

        private StringBuilder GetText(int startIndex, int stopIndex)
        {

            int length = stopIndex - startIndex;

            length++;

            StringBuilder sb2 = new StringBuilder(length);
            char[] ar = new char[length];
            _initialSource.CopyTo(startIndex, ar, 0, length);
            sb2.Append(ar);

            return sb2;

        }

        private StringBuilder _initialSource;
        private Dictionary<string, DefinitionModel> _items = new Dictionary<string, DefinitionModel>();
        private List<ErrorModel> _errors;
    }

}
