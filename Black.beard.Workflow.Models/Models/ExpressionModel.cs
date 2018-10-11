using System;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// Expression base
    /// </summary>
    public class ExpressionModel
    {

        public object Evaluator { get; set; }

        public bool Evaluate<TContext>(TContext context)
        {
            var e = Evaluator as Func<TContext, bool>;
            return e(context);
        }

        /// <summary>
        /// Pattern visitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public virtual T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitExpression(this);
        }

    }

}