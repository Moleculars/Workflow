namespace Bb.Compilers.Models
{

    public abstract class CompilerBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerBase"/> class.
        /// </summary>
        public CompilerBase()
        {

        }

        /// <summary>
        /// Gets or sets the name of the object.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the description of the object
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }


        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns></returns>
        public abstract object Accept(CompilerBaseVisitor visitor);

        public int LineNumber;
        public int LinePosition;

    }
}