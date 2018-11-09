using Bb.Compilers;
using Bb.Compilers.Models;
using Bb.Compilers.Pocos;
using System;

namespace Bb.Workflow.Configurations
{

    internal class StateCompilerVisitor : CompilerModelTranslatorVisitor
    {

        public StateCompilerVisitor(PocoModelRepository repository)
            : base(repository)
        {

        }

        public override object Visit(CompilerModelRoot root)
        {

            if (root.BaseName == "State")
                root.BaseName = "WorkflowModel";

            else if (root.BaseName == "Event")
                root.BaseName = "StateEvent";

            var result = base.Visit(root);

            base._repository.AddUsings(
                "Bb.Workflow.Models",
                "Bb.Core"
            );

            return result;

        }

    }


}
