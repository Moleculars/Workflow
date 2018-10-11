namespace Bb.Workflow.Models
{

    /// <summary>
    /// Reference base model
    /// </summary>
    public class ReferenceModel
    {

        /// <summary>
        /// Name of the reference or the model
        /// </summary>
        public string Key { get; set; }

        public virtual T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitReference(this);
        }


    }

}