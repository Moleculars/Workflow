using Bb.Compilers;
using Bb.Compilers.Models;
using Bb.Compilers.Pocos;
using Bb.ComponentModel.Attributes;
using Bb.Core;

namespace Bb.Mappings.Configurations
{

    internal class MappingCompilerVisitor : CompilerModelTranslatorVisitor
    {
        private readonly string _domain;
        private readonly string _version;

        public MappingCompilerVisitor(PocoModelRepository repository, string domain, string version)
            : base(repository)
        {
            this._domain = domain;
            this._version = version;
        }

        public override object Visit(CompilerModelRoot root)
        {

            root.BaseName = string.Empty;
            var result = (PocoModel)base.Visit(root);

            result.Interfaces.Add(nameof(ISourceEvent));

            base._repository.AddUsings(
                typeof(ISourceEvent),
                typeof(ExposeIncomingMessage)
    );


            return result;

        }

    }


}
