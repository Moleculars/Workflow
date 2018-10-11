using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// define switch model that describe conditions, and delay of the switch
    /// </summary>
    public class SwitchDefinitionModel : DefinitionModel
    {

        public SwitchDefinitionModel()
        {
            this.ToExecutes = new List<ActionReferenceModel>();
        }

        /// <summary>
        /// delay in minute before execution
        /// </summary>
        public int Delay { get; set; }

        /// <summary>
        /// List of method to execute
        /// </summary>
        public List<ActionReferenceModel> ToExecutes { get; set; }

        /// <summary>
        /// condition to evaluate before switch
        /// </summary>
        public ExpressionModel When { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Delay > 0)
                sb.Append($"after {Delay} minute(s), ");

            if (When != null)
                sb.Append($"when {When.ToString()} ");

            sb.Append($"switch to {Key} for {Comment}");

            return sb.ToString();
        }

        /// <summary>
        /// Pattern visitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitSwitch(this);
        }


    }

}
