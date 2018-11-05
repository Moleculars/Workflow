namespace Bb.Compilers.Models
{

    public class CompilerModel : CompilerBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerModel"/> class.
        /// </summary>
        public CompilerModel()
        {
            Properties = new CompilerProperties();
        }

        /// <summary>
        /// Gets or sets the name of the base class.
        /// </summary>
        /// <value>
        /// The name of the base.
        /// </value>
        public string BaseName { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        public CompilerProperties Properties { get; set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns></returns>
        public override object Accept(CompilerBaseVisitor visitor)
        {
            return visitor.Visit(this);
        }

    }

}
