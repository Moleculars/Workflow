using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.BusinessRule.Models
{

    /// <summary>
    /// Result model from rule's processor
    /// </summary>
    public class ResultModel
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kindAction">can be 'Create' or 'Drop'</param>
        /// <param name="familyObject">used for categorize event</param>
        /// <param name="objectName">object name</param>
        public ResultModel(string familyObject, string objectName)
        {
            this.FamilyObject = familyObject;
            this.ObjectName = objectName;
        }

        /// <summary>
        /// Family object category
        /// </summary>
        public string FamilyObject { get; }

        /// <summary>
        /// object name
        /// </summary>
        public string ObjectName { get; }

        public bool ResultEvaluationWorkflow { get; set; }

    }

}
