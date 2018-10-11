namespace Bb.Workflow.Models
{

    /// <summary>
    /// Definition model base
    /// </summary>
    public class DefinitionModel : ReferenceModel
    {

        public string Comment { get; set; }

        public override string ToString()
        {
            return $"{Key} -> '{Comment}'";
        }

        /// <summary>
        /// Pattern visitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitDefinition(this);
        }

    }

}
