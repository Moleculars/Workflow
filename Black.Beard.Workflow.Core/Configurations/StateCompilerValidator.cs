using Bb.Compilers.Models;
using Bb.Compilers.Pocos;

namespace Bb.Workflow.Configurations
{
    internal class StateCompilerValidator : ValidateCompilerVisitor
    {
        
        public override object Visit(CompilerModelRoot root)
        {

            if (string.IsNullOrEmpty(root.Key))
                Add(root, "Key", "property 'Key' must be Specified");

            if (root.BaseName != "State" && root.BaseName != "Event")
                Add(root, "BaseName", "property 'BaseName' is restricted (State, Event)");

            var result = base.Visit(root);

            return result;

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

