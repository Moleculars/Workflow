using Bb.BusinessRule.Models;
using Bb.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
namespace Bb.BusinessRule.Core.Configurations
{

    public class BuildBusinessRuleVisitor<TContext> : IVisitor
    {


        public BuildBusinessRuleVisitor(TypeReferential typeReferential)
        {

            this._ruleActions = MethodDiscovery.GetActions<TContext>(typeReferential, true, typeof(bool), typeof(TContext));
            this._loadDataActions = MethodDiscovery.GetActions<TContext>(typeReferential, true, typeof(void), typeof(TContext));

            this._context = Expression.Parameter(typeof(TContext), "context");
            this._result = Expression.Parameter(typeof(List<ResultModel>), "result");

            this._addMethodList = typeof(List<ResultModel>).GetMethod("Add");

            this._resultModelCtor = typeof(ResultModel).GetConstructor(new Type[] { typeof(string), typeof(string) });

        }



        public Expression VisitAction(ActionCodeBRExpression e)
        {

            if (_ruleActions.TryGetValue(e.Name, out BusinessAction<TContext> b))
            {

                List<Expression> arguments = new List<Expression>(e.Arguments.Count + 1)
                {
                    this._context
                };

                foreach (var item in e.Arguments)
                {
                    Expression expression = item.Accept(this);
                    arguments.Add(expression);
                }

                return b.GetCallAction(arguments.ToArray());

            }

            Stop();
            throw new NotImplementedException(e.Name);

        }


        public Expression VisitLoadData(LoadDataCodeBRExpression e)
        {
            if (_loadDataActions.TryGetValue(e.Name, out BusinessAction<TContext> b))
            {

                List<Expression> arguments = new List<Expression>(e.Arguments.Count + 1)
                {
                    this._context
                };

                foreach (var item in e.Arguments)
                {
                    Expression expression = item.Accept(this);
                    arguments.Add(expression);
                }

                return b.GetLoadDatasAction(arguments.ToArray());

            }

            Stop();
            throw new NotImplementedException(e.Name);

        }

        public Expression VisitBinary(BinaryCodeBRExpression e)
        {

            Expression result = null;

            var left = e.Left.Accept(this);
            var right = e.Right.Accept(this);

            switch (e.Operator)
            {
                case OperatorsEnum.EQUAL:
                    result = Expression.MakeBinary(ExpressionType.Equal, left, right);
                    break;

                case OperatorsEnum.NOT_EQUAL:
                    result = Expression.MakeBinary(ExpressionType.NotEqual, left, right);
                    break;

                case OperatorsEnum.GREATER:
                    result = Expression.MakeBinary(ExpressionType.GreaterThan, left, right);
                    break;

                case OperatorsEnum.GREATER_OR_EQUAL:
                    result = Expression.MakeBinary(ExpressionType.GreaterThanOrEqual, left, right);
                    break;

                case OperatorsEnum.LESS:
                    result = Expression.MakeBinary(ExpressionType.LessThan, left, right);
                    break;

                case OperatorsEnum.LESS_OR_EQUAL:
                    result = Expression.MakeBinary(ExpressionType.LessThanOrEqual, left, right);
                    break;


                case OperatorsEnum.PLUS:
                    result = Expression.Add(left, right);
                    break;
                case OperatorsEnum.MINUS:
                    result = Expression.Subtract(left, right);
                    break;
                case OperatorsEnum.TIME:
                    result = Expression.Multiply(left, right);
                    break;
                case OperatorsEnum.DIVID:
                    result = Expression.Divide(left, right);
                    break;
                case OperatorsEnum.MODULO:
                    result = Expression.Modulo(left, right);
                    break;
                case OperatorsEnum.POWER:
                    result = Expression.Power(left, right);
                    break;


                case OperatorsEnum.AND:
                    result = Expression.MakeBinary(ExpressionType.And, left, right);
                    break;
                case OperatorsEnum.ANDALSO:
                    result = Expression.MakeBinary(ExpressionType.AndAlso, left, right);
                    break;
                case OperatorsEnum.OR:
                    result = Expression.MakeBinary(ExpressionType.Or, left, right);
                    break;
                case OperatorsEnum.XOR:
                    result = Expression.MakeBinary(ExpressionType.OrElse, left, right);
                    break;
                default:
                    break;

            }

            Debug.Assert(result != null);

            return result;

        }

        public Expression VisitConstant(ConstantCodeBRExpression e)
        {
            return Expression.Constant(e.Value);
        }

        public Expression VisitNot(NotCodeBRExpression e)
        {
            var value = e.Sub.Accept(this);
            return Expression.Not(value);
        }

        public Expression VisitReturn(RuleResultReturn e)
        {

            return Expression.New
                (this._resultModelCtor
                 , Expression.Constant(e.ObjectKind.Name)
                 , Expression.Constant(e.ObjectName.Name)
                );

        }

        public Expression VisitRule(Rule r)
        {

            // Condition
            var when = r.When.Accept(this);

            var result = r.Then.Accept(this);
            var arg = this._result;
            var addItem = Expression.Call(arg, this._addMethodList, result);

            ConditionalExpression condition;
            if (r.Else != null)
            {
                Expression _else = r.Else.Accept(this);
                condition = Expression.Condition(when, addItem, _else);
            }
            else
                condition = Expression.IfThen(when, addItem);

            return condition;

        }

        public Expression VisitRepository(RuleRepository rep)
        {

            List<Expression> _datas = new List<Expression>();
            List<Expression> _block = new List<Expression>();

            foreach (LoadDataCodeBRExpression loadData in rep.LoadDatas)
            {
                var result = loadData.Accept(this);
                _datas.Add(result);
            }

            // Add alls rules
            foreach (Rule rule in rep.Rules)
            {
                var result = rule.Accept(this);
                _block.Add(result);
            }

            // Build the method
            var @delegate = Expression.Lambda<Action<TContext, List<ResultModel>>>
            (
                Expression.Block(_block)
                , this._context
                , this._result
            );

            var @delegate2 = Expression.Lambda<Action<TContext>>
            (
                Expression.Block(_datas)
                , this._context
            );

            rep.MethodLoadDatas = @delegate2.Compile();

            return @delegate;

        }

        public Expression VisitIdentifier(Identifier e)
        {
            return Expression.Constant(e.Name);
        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        private void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

        private readonly MethodInfo _addMethodList;
        private readonly ConstructorInfo _resultModelCtor;
        private Dictionary<string, BusinessAction<TContext>> _ruleActions;
        private readonly Dictionary<string, BusinessAction<TContext>> _loadDataActions;
        private ParameterExpression _context;
        private readonly ParameterExpression _result;


    }

}
