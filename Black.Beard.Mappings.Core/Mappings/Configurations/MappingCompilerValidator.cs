using Bb.Compilers.Models;

namespace Bb.Mappings
{

    internal class MappingCompilerValidator : ValidateCompilerVisitor
    {

        public override object Visit(CompilerModelRoot root)
        {
            base.Visit(root);


            return null;

        }

        public override object Visit(CompilerModel model)
        {
            return base.Visit(model);
        }

        public override object Visit(CompilerProperty property)
        {
            return base.Visit(property);
        }


    }

}
