using Bb.ComponentModel;
using Bb.Workflow.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Workflow.Configurations
{

    public class StateConverterVisitor<TContext> : IVisitor<Expression> // where TContext : Context
    {

        public StateConverterVisitor()
        {
            this._actions = MethodDiscovery.GetActions<TContext>(true, typeof(bool), typeof(TContext));
            this._context = Expression.Parameter(typeof(TContext), "context");
        }

        private ParameterExpression _context;


        public Expression ActionReference(ActionReferenceModel m)
        {
            throw new NotImplementedException();
        }

        public Expression VisitAction(ActionDefinitionModel m)
        {
            throw new NotImplementedException();
        }

        public Expression VisitBinary(BinaryExpressionModel m)
        {

            BinaryExpression result = null;

            var left = m.Left.Accept(this);
            var right = m.Right.Accept(this);

            switch (m.Operator)
            {
                case "AND":
                    result = Expression.And(left, right);
                    break;

                case "OR":
                    result = Expression.Or(left, right);
                    break;             

                default:
                    break;
            }

            Debug.Assert(result != null);
            return result;

        }

        public Expression VisitDefinition(DefinitionModel m)
        {
            throw new NotImplementedException();
        }

        public Expression VisitEvent(EventDefinitionModel m)
        {
            throw new NotImplementedException();
        }

        public Expression VisitExpression(ExpressionModel m)
        {
            throw new NotImplementedException();
        }

        public Expression VisitOnEvent(OnEventReferenceModel m)
        {

            foreach (SwitchDefinitionModel @switch in m.Switchs)
                @switch.Accept(this);

            return null;
        }

        public Expression VisitReference(ReferenceModel m)
        {
            throw new NotImplementedException();
        }

        public Expression VisitRule(RuleDefinitionModel m)
        {

            var key = m.Key;
            if (_actions.TryGetValue(key, out BusinessAction<TContext> b))
            {

                List<Expression> arguments = new List<Expression>(/*m.Arguments.Count + */1)
                {
                    this._context
                };

                //foreach (var item in m.Arguments)
                //    arguments.Add(item.Accept(this));

                return b.GetCallAction(arguments.ToArray());

            }

            throw new NotImplementedException(key);

        }

        public Expression VisitRuleExpression(RuleExpressionModel m)
        {
            return m.Reference.Accept(this);
        }

        public Expression VisitState(StateDefinitionModel m)
        {

            foreach (OnEventReferenceModel onEvent in m.Events)
                onEvent.Accept(this);                

            return null;
        }

        public Expression VisitSwitch(SwitchDefinitionModel m)
        {

            if (m.When != null)
            {
                var body = m.When.Accept(this);
                var lambda = Expression.Lambda<Func<TContext, bool>>(body, this._context);
                m.When.Evaluator = lambda.Compile();
            }

            return null;

        }

        public Expression VisitWorkflow(WorkflowDefinitionModel m)
        {
      
            foreach (var state in m.States)
                state.Accept(this);

            return null;

        }


        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        private void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

        private Dictionary<string, BusinessAction<TContext>> _actions;

    }

}
