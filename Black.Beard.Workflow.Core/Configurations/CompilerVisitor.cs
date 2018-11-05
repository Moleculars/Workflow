using Bb.Compilers;
using Bb.Compilers.Models;
using Bb.Compilers.Pocos;
using System;

namespace Bb.Workflow.Configurations
{

    internal class CompilerVisitor : CompilerModelTranslatorVisitor
    {

        public CompilerVisitor(PocoModelRepository repository)
            : base(repository)
        {

        }

        public override object Visit(CompilerModelRoot root)
        {

            root.BaseName = "WorkflowModel";
            var result = base.Visit(root);

            base._repository.AddUsings(
                "Bb.Workflow.Models"
            );

            return result;

        }

    }


}
