using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Contain a method discovered
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    [System.Diagnostics.DebuggerDisplay("{RuleName}")]
    public class BusinessAction<TContext>
    {

        public BusinessAction()
        {

        }

        /// <summary>
        /// Return an expression from the method
        /// </summary>
        /// <param name="argumentContext"></param>
        /// <returns></returns>
        public Expression GetCallAction(params Expression[] arguments)
        {

            // build custom method
            List<Expression> _args = new List<Expression>(arguments.Length);
            var parameters = this.Method.GetParameters();

            for (int i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];
                var parameter = parameters[i];

                if (argument.Type != parameter.ParameterType)
                {

                    if (argument is ConstantExpression c)
                        argument = Expression.Constant(Convert.ChangeType(c.Value, parameter.ParameterType));

                    else
                    {
                        if (System.Diagnostics.Debugger.IsAttached)
                            System.Diagnostics.Debugger.Break();
                        argument = Expression.Convert(argument, parameter.ParameterType);
                    }

                }
                _args.Add(argument);
            }

            var m = Expression.Call(this.Method, _args.ToArray());


            // Build log method
            List<Expression> _args2 = new List<Expression>(arguments.Length + 2);
            _args2.Add(Expression.Constant(this.RuleName));
            _args2.Add(m);

            List<string> _args3 = new List<string>(4);

            for (int i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];

                if (argument.Type == typeof(TContext))
                    _args2.Add(argument);

                else if (argument is ConstantExpression c)
                    _args3.Add(c.Value.ToString());

                else
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                        System.Diagnostics.Debugger.Break();
                }

            }

            _args2.Add(Expression.Constant(_args3.ToArray()));
            MethodInfo method2 = typeof(BusinessAction<TContext>).GetMethod("LogResult", BindingFlags.Static | BindingFlags.Public);
            var m2 = Expression.Call(method2, _args2.ToArray());

            return m2;

        }

        /// <summary>
        /// Attention on y fait bien référence par reflexion dans la methode précédente.
        /// </summary>
        /// <param name="ruleName"></param>
        /// <param name="result"></param>
        /// <param name="context"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static bool LogResult(string ruleName, bool result, TContext context, string[] arguments)
        {
            string message = $"{ruleName}({string.Join(", ", arguments)}) => {result}";
            return result;
        }


        /// <summary>
        /// Return an expression from the method
        /// </summary>
        /// <param name="argumentContext"></param>
        /// <returns></returns>
        public Expression GetLoadDatasAction(params Expression[] arguments)
        {

            // build custom method
            List<Expression> _args = new List<Expression>(arguments.Length);
            var parameters = this.Method.GetParameters();

            for (int i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];
                var parameter = parameters[i];

                if (argument.Type != parameter.ParameterType)
                {

                    if (argument is ConstantExpression c)
                        argument = Expression.Constant(Convert.ChangeType(c.Value, parameter.ParameterType));

                    else
                    {
                        if (System.Diagnostics.Debugger.IsAttached)
                            System.Diagnostics.Debugger.Break();
                        argument = Expression.Convert(argument, parameter.ParameterType);
                    }

                }
                _args.Add(argument);
            }

            var m = Expression.Call(this.Method, _args.ToArray());


            //// Build log method
            //List<Expression> _args2 = new List<Expression>(arguments.Length + 2);
            //_args2.Add(Expression.Constant(this.RuleName));
            //_args2.Add(m);

            //List<string> _args3 = new List<string>(4);

            //for (int i = 0; i < arguments.Length; i++)
            //{
            //    var argument = arguments[i];

            //    if (argument.Type == typeof(TContext))
            //        _args2.Add(argument);

            //    else if (argument is ConstantExpression c)
            //        _args3.Add(c.Value.ToString());

            //    else
            //    {
            //        if (System.Diagnostics.Debugger.IsAttached)
            //            System.Diagnostics.Debugger.Break();
            //    }

            //}

            //_args2.Add(Expression.Constant(_args3.ToArray()));

            //MethodInfo method2 = typeof(BusinessAction<TContext>).GetMethod("LogResult", BindingFlags.Static | BindingFlags.Public);

            //var m2 = Expression.Call(method2, _args2.ToArray());


            return m;

        }

        public MethodInfo Method { get; internal set; }

        public string RuleName { get; internal set; }

        public Type Type { get; internal set; }

        public string Origin { get; internal set; }

    }

}