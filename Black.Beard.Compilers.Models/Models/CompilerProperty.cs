namespace Bb.Compilers.Models
{

    public class CompilerProperty : CompilerBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerProperty"/> class.
        /// </summary>
        public CompilerProperty()
        {

        }

        /// <summary>
        /// Gets or sets a value indicating whether this property is an array.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is array; otherwise, <c>false</c>.
        /// </value>
        public bool IsArray { get; set; }

        /// <summary>
        /// Gets or sets the type name.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }

        public override object Accept(CompilerBaseVisitor visitor)
        {
            return visitor.Visit(this);
        }

    }


}
