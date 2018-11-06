namespace Bb.Compilers.Models
{

    public abstract class CompilerBaseVisitor
    {

        /// <summary>
        /// Visits the specified compiler model root.
        /// </summary>
        /// <param name="compilerModel">The compiler model.</param>
        /// <returns></returns>
        public abstract object Visit(CompilerModelRoot root);

        /// <summary>
        /// Visits the specified compiler model.
        /// </summary>
        /// <param name="compilerModel">The compiler model.</param>
        /// <returns></returns>
        public abstract object Visit(CompilerModel model);

        /// <summary>
        /// Visits the specified compiler property.
        /// </summary>
        /// <param name="compilerProperty">The compiler property.</param>
        /// <returns></returns>
        public abstract object Visit(CompilerProperty property);
        
    }
}