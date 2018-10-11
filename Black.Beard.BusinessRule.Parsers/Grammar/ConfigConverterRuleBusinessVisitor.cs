using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Bb.BusinessRule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.BusinessRule.Parser.Grammar
{

    public class ConfigConverterRuleBusinessVisitor : BusinessRuleParserBaseVisitor<object>
    {

        public ConfigConverterRuleBusinessVisitor()
        {


        }

        public override object Visit(IParseTree tree)
        {
            this._errors = new List<ErrorModel>();
            EvaluateErrors(tree);

            return base.Visit(tree);

        }

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

        /// <summary>
        /// script :
        ///     NAME identifier
        ///     declare_constants
        ///     EVENT CHAR_STRING
        ///     (DESCRIPTION comment)?
        ///     (MATCHING matchings+)?
        ///     (unit_statement SEMICOLON) * EOF
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitScript([NotNull] BusinessRuleParser.ScriptContext context)
        {

            var identifier = context.identifier();

            if (identifier == null)
                throw new Exception($"name of script is required");

            this._initialSource = new StringBuilder(context.Start.InputStream.ToString());

            var repository = new RuleRepository()
            {
                Name = (Identifier)VisitIdentifier(identifier),
            };

            if (context.EVENT() == null)
                throw new Exception("Missing event name");

            repository.EventName = context.CHAR_STRING().GetText().Replace("'", "");

            if (context.DESCRIPTION() != null)
                repository.Comment = (string)VisitComment(context.comment());

            if (context.MATCHING() != null)
            {
                foreach (var matchings in context.matchings())
                    repository.Matchings.Add((List<KeyValuePair<string, string>>)VisitMatchings(matchings));
            }

            var constants = context.declare_constants();
            if (constants != null)
                VisitDeclare_constants(constants);

            foreach (var item in context.unit_statement())
            {
                var rule = VisitUnit_statement(item);
                if (rule is Rule r)
                    repository.Rules.Add(r);
                else if (rule is LoadDataCodeBRExpression l)
                    repository.LoadDatas.Add(l);

                else
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                        System.Diagnostics.Debugger.Break();
                }
            }

            return repository;
        }

        public override object VisitDeclare_constants([NotNull] BusinessRuleParser.Declare_constantsContext context)
        {
            foreach (BusinessRuleParser.Declare_constantContext declare_constant in context.declare_constant())
            {
                var constant = (Constant)VisitDeclare_constant(declare_constant);
                this._constants.Add(constant.Identifier.Name, constant);
            }

            return null;

        }

        /// <summary>
        /// CONST identifier constant comment
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitDeclare_constant([NotNull] BusinessRuleParser.Declare_constantContext context)
        {
            var key = (Identifier)VisitIdentifier(context.identifier());
            var c = (ConstantCodeBRExpression)VisitConstant(context.constant());

            string comment = string.Empty;
            var cc = context.comment();
            if (cc != null)
                comment = (string)VisitComment(cc);

            return new Constant(key, c) { Comment = comment };

        }

        public override object VisitMatchings([NotNull] BusinessRuleParser.MatchingsContext context)
        {
            List<KeyValuePair<string, string>> _result = new List<KeyValuePair<string, string>>();
            foreach (var matching in context.matching())
                _result.Add((KeyValuePair<string, string>)VisitMatching(matching));
            return _result
                .OrderBy(c => c.Key + c.Value)
                .ToList();
        }

        /// <summary>
        /// matching : identifier EQUAL CHAR_STRING;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitMatching([NotNull] BusinessRuleParser.MatchingContext context)
        {
            var key = (Identifier)VisitIdentifier(context.identifier());
            var char_string = context.CHAR_STRING();
            var value = char_string.Symbol.Text.Trim().Trim('\'');
            return new KeyValuePair<string, string>(key.Name, value);
        }

        /// <summary>
        /// comment : CHAR_COMMENT;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitComment([NotNull] BusinessRuleParser.CommentContext context)
        {
            var result = context.GetText().Trim('"');
            return result;
        }

        ///// <summary>
        ///// FUNCTION identifier LEFT_PAREN parameters RIGHT_PAREN
        ///// </summary>
        ///// <param name="context"></param>
        ///// <returns></returns>
        //public override object VisitFunction([NotNull] BusinessRuleParser.FunctionContext context)
        //{
        //}

        ///// <summary>
        ///// parameters :
        /////     parameter(COMMA parameter)*
        /////     ;
        ///// </summary>
        ///// <param name="context"></param>
        ///// <returns></returns>
        //public override object VisitParameters([NotNull] BusinessRuleParser.ParametersContext context)
        //{
        //}

        ///// <summary>
        ///// parameter :
        /////     identifier
        /////     ;
        ///// </summary>
        ///// <param name="context"></param>
        ///// <returns></returns>
        //public override object VisitParameter([NotNull] BusinessRuleParser.ParameterContext context)
        //{
        //}

        /// <summary>
        /// LOAD DATA identifier LEFT_PAREN parameters RIGHT_PAREN
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitLoad_data([NotNull] BusinessRuleParser.Load_dataContext context)
        {

            var act = new LoadDataCodeBRExpression()
            {
                Name = (VisitIdentifier(context.identifier()) as Identifier).Name,
            };

            var args = context.arguments();
            if (args != null)
                act.Arguments.AddRange((List<CodeBRExpression>)VisitArguments(args));

            return act;


        }

        /// <summary>
        /// rule :
        ///     WHEN expre_action thenResult=result (ELSE else=rule)?
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitRule([NotNull] BusinessRuleParser.RuleContext context)
        {

            var rule = new Rule()
            {
                When = (CodeBRExpression)VisitExpre_action(context.expre_action()),
                Then = (RuleResultReturn)VisitResult(context.thenResult),
            };

            if (context.elseRule != null)
                rule.Else = (Rule)VisitRule(context.elseRule);

            return rule;

        }

        /// <summary>
        /// result : 
        ///    RETURN(CREATE | DROP) identifier identifier
        ///    ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitResult([NotNull] BusinessRuleParser.ResultContext context)
        {

            var id = context.identifier();
            var r = new RuleResultReturn()
            {
                ObjectKind = (VisitIdentifier(id[0]) as Identifier),
                ObjectName = (VisitIdentifier(id[1]) as Identifier),
            };

            return r;

        }

        /// <summary>
        /// expre_action :
        ///       not1=NOT? action (operator=(AND | ANDALSO | OR | XOR) not2=NOT? exp2=expre_action)?
        ///     | not1=NOT? LEFT_PAREN exp1=expre_action RIGHT_PAREN (operator=(AND | ANDALSO | OR | XOR) not2=NOT? exp2=expre_action)?
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitExpre_action([NotNull] BusinessRuleParser.Expre_actionContext context)
        {

            CodeBRExpression result = null;
            CodeBRExpression left = null;
            CodeBRExpression right = null;

            var action = context.action();
            if (action != null)
            {

                left = (CodeBRExpression)VisitAction(context.action());
                if (context.not1 != null)
                    left = new NotCodeBRExpression() { Sub = left };
            }
            else
            {
                left = (CodeBRExpression)VisitExpre_action(context.exp1);
                if (context.not1 != null)
                    left = new NotCodeBRExpression() { Sub = left };
            }

            if (context.exp2 != null)
            {
                right = (CodeBRExpression)VisitExpre_action(context.exp2);
                if (context.not2 != null)
                    right = new NotCodeBRExpression() { Sub = right };

                var ope = context.@operator;
                result = new BinaryCodeBRExpression()
                {
                    Left = left,
                    Operator = (OperatorsEnum)Parse(ope.Text.ToUpper().Trim()),
                    Right = right,
                };

            }
            else
                result = left;

            return result;

        }

        private OperatorsEnum Parse(string text)
        {

            switch (text)
            {
                case "=":
                    return OperatorsEnum.EQUAL;
                case "!=":
                    return OperatorsEnum.NOT_EQUAL;
                case ">":
                    return OperatorsEnum.GREATER;
                case ">=":
                    return OperatorsEnum.GREATER_OR_EQUAL;
                case "<":
                    return OperatorsEnum.LESS;
                case "<=":
                    return OperatorsEnum.LESS_OR_EQUAL;
                case "+":
                    return OperatorsEnum.PLUS;
                case "-":
                    return OperatorsEnum.MINUS;
                case "*":
                    return OperatorsEnum.TIME;
                case "/":
                    return OperatorsEnum.DIVID;
                case "%":
                    return OperatorsEnum.MODULO;
                case "^":
                    return OperatorsEnum.POWER;
                case "&":
                    return OperatorsEnum.AND;
                case "&&":
                    return OperatorsEnum.ANDALSO;
                case "|":
                    return OperatorsEnum.OR;
                case "||":
                    return OperatorsEnum.XOR;

                default:
                    throw new NotImplementedException(text);

            }

        }


        /// <summary>
        /// action : 
        ///     identifier LEFT_PAREN arguments? RIGHT_PAREN
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitAction([NotNull] BusinessRuleParser.ActionContext context)
        {

            var act = new ActionCodeBRExpression()
            {
                Name = (VisitIdentifier(context.identifier()) as Identifier).Name,
            };

            var args = context.arguments();
            if (args != null)
                act.Arguments.AddRange((List<CodeBRExpression>)VisitArguments(args));

            return act;

        }

        /// <summary>
        /// arguments : argument (COMMA argument)*;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitArguments([NotNull] BusinessRuleParser.ArgumentsContext context)
        {

            List<CodeBRExpression> args = new List<CodeBRExpression>();

            foreach (var arg in context.argument())
                args.Add((CodeBRExpression)VisitArgument(arg));

            return args;
        }

        /// <summary>
        /// argument : 
        ///       constant
        ///     | identifier
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitExpre([NotNull] BusinessRuleParser.ExpreContext context)
        {
            var _constant = context.constant();
            if (_constant != null)
                return VisitConstant(_constant);

            var identifiers = context.identifiers();

            var ids = (Identifier)VisitIdentifiers(identifiers);

            if (ids.Sub == null)    // On essai de matcher sur une constante
            {
                if (this._constants.TryGetValue(ids.Name, out Constant c))
                    return c.Value;

                else
                {

                }
            }

            return ids;

        }

        /// <summary>
        /// identifier (DOT identifier)*;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitIdentifiers([NotNull] BusinessRuleParser.IdentifiersContext context)
        {

            var identifiers = context.identifier();

            Identifier f = null;
            Identifier e = null;
            Identifier l = null;

            foreach (var item in identifiers)
            {

                e = (Identifier)VisitIdentifier(item);

                if (l == null)
                    f = e;

                else
                    l.Sub = e;

                l = e;

            }

            return f;

        }

        /// <summary>
        /// identifier : CHAR_STRING | REGULAR_ID;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitIdentifier([NotNull] BusinessRuleParser.IdentifierContext context)
        {

            var r = context.REGULAR_ID();
            if (r != null)
                return new Identifier() { Name = r.GetText() };

            var c = context.CHAR_STRING().GetText().Trim('\'');

            return new Identifier() { Name = c };

        }

        /// <summary>
        /// constant : 
        ///       number d1 = 
        ///     | number operation number
        ///     | number comparer number
        ///     | string (PLUS string)
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitConstant([NotNull] BusinessRuleParser.ConstantContext context)
        {

            var numbers = context.number();
            if (numbers != null && numbers.Length > 0)
            {
                var n = VisitNumber(numbers[0]);
                return new ConstantCodeBRExpression() { Value = n };
            }
            else
            {
                var strings = context.@string();
                StringBuilder sb = new StringBuilder();

                foreach (var s in strings)
                {
                    var _s = s.GetText().Trim('\'');
                    sb.Append(_s);
                }

                return new ConstantCodeBRExpression() { Value = sb.ToString() };

            }


        }

        /// <summary>
        /// integer : (PLUS|MINUS)? NUMBER delay?;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitInteger([NotNull] BusinessRuleParser.IntegerContext context)
        {
            var integer = int.Parse(context.NUMBER().GetText());

            var d = context.delay();
            if (d != null)
            {

                var i = (DelayUnityEnum)VisitDelay(d);
                switch (i)
                {
                    case DelayUnityEnum.HOUR:
                        integer = integer * 60;
                        break;

                    case DelayUnityEnum.DAY:
                        integer = integer * 60 * 24;
                        break;

                }
            }

            if (context.MINUS() != null)
                integer = integer - (integer * 2);



            return integer;

        }

        /// <summary>
        /// float : (PLUS|MINUS)? NUMBER (COMMA NUMBER)?;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitFloat([NotNull] BusinessRuleParser.FloatContext context)
        {

            float f = 0;

            var numbers = context.NUMBER();

            var dec = numbers[0].GetText();
            if (numbers.Length == 2)
            {
                dec += "," + numbers[1].GetText();
                f = float.Parse(dec);
            }

            if (context.MINUS() != null)
                f = f - (f * 2);

            return f;

        }

        /// <summary>
        /// delay : MINUTE | HOUR | DAY;
        /// ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitDelay([NotNull] BusinessRuleParser.DelayContext context)
        {
            var _operator = Enum.Parse(typeof(DelayUnityEnum), context.GetText().ToUpper().Trim());
            return _operator;
        }

        /// <summary>
        /// comparer : 
        ///       EQUAL 
        ///     | NOT_EQUAL
        ///     | GREATER 
        ///     | GREATER_OR_EQUAL 
        ///     | LESS 
        ///     | LESS_OR_EQUAL
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitComparer([NotNull] BusinessRuleParser.ComparerContext context)
        {
            var _operator = Parse(context.GetText().ToUpper().Trim());
            return _operator;
        }

        /// <summary>
        /// operation : 
        ///       PLUS 
        ///     | MINUS 
        ///     | TIME 
        ///     | DIVID
        ///     | MODULO
        ///     | POWER
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitOperation([NotNull] BusinessRuleParser.OperationContext context)
        {
            var _operator = Parse(context.GetText().ToUpper().Trim());
            return _operator;
        }


        public string Filename { get; set; }



        private class Constant
        {

            public readonly Identifier Identifier;
            public readonly ConstantCodeBRExpression Value;

            public Constant(Identifier identifier, ConstantCodeBRExpression value)
            {
                this.Identifier = identifier;
                this.Value = value;
            }

            public string Comment { get; internal set; }
        }


        private StringBuilder _initialSource;
        private List<ErrorModel> _errors;
        private Dictionary<string, Constant> _constants = new Dictionary<string, Constant>();

    }

}
