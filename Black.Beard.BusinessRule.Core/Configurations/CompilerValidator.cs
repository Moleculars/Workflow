using Bb.Compilers.Models;

namespace Bb.BusinessRule.Configurations
{
    internal class CompilerValidator : ValidateCompilerVisitor
    {

        public override object Visit(CompilerModelRoot root)
        {
            base.Visit(root);

            if (string.IsNullOrEmpty(root.Key))
                Add(root, "Key", "property key must be Specified");

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
