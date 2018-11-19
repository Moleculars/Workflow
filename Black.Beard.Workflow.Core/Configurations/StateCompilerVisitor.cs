using Bb.Compilers;
using Bb.Compilers.Models;
using Bb.Compilers.Pocos;

namespace Bb.Workflow.Configurations
{

    internal class StateCompilerVisitor : CompilerModelTranslatorVisitor
    {

        public StateCompilerVisitor(PocoModelRepository repository, string domain, string version)
            : base(repository)
        {
            _domain = domain;
            _version = version;
        }

        public override object Visit(CompilerModelRoot root)
        {

            if (root.BaseName == "State")
                root.BaseName = "WorkflowModel";

            else if (root.BaseName == "Event")
                root.BaseName = "StateEvent";

            var result = (PocoModel)base.Visit(root);

            base._repository.AddUsings(
                "Bb.Workflow.Models",
                "Bb.Core"
            );

            result.Attributes.Add(
                new PocoModelAttribute("ExposeModel",
                new PocoModelAttributeArgument() { Value = _domain, IsString = true },
                new PocoModelAttributeArgument() { Value = _version, IsString = true },
                new PocoModelAttributeArgument() { Value = root.Key, IsString = true },
                new PocoModelAttributeArgument() { Value = root.BaseName == "WorkflowModel" ? "State" : "Event", IsString = true }
            ));

            return result;

        }

        private readonly string _domain;
        private readonly string _version;

    }


}
