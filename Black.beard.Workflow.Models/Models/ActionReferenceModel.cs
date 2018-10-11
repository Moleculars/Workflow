using System;
using System.Collections.Generic;

namespace Bb.Workflow.Models
{

    /// <summary>
    /// descript an action to execute
    /// </summary>
    public class ActionReferenceModel : ReferenceModel
    {

        public ActionReferenceModel()
        {
            Arguments = new List<string>();
        }

        /// <summary>
        /// reference to the action
        /// </summary>
        public ActionDefinitionModel Reference { get; set; }

        /// <summary>
        /// define if the action must be executed then entering or exiting to a state
        /// </summary>
        public OnEventEnum Way { get; set; }

        /// <summary>
        /// List of argument passing in the method
        /// </summary>
        public List<string> Arguments { get; set; }

        /// <summary>
        /// Pattern visitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.ActionReference(this);
        }

    }

    [Flags]
    public enum OnEventEnum
    {
        Unspecified,
        OnEnter,
        OnExit,
        OnBoth,
        OnEvent,
    }

}
