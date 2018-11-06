using System.Collections.Generic;

namespace Bb.Compilers.Models
{

    public class ValidateCompilerVisitor : CompilerBaseVisitor
    {

        public ValidateCompilerVisitor()
        {
            _items = new List<CompilerBaseDiagnostic>();
        }

        public override object Visit(CompilerModelRoot root)
        {

            if (string.IsNullOrEmpty(root.Name))
                Add(root, "Name", "property Name must be Specified");

            foreach (CompilerProperty prop in root.Properties)
                prop.Accept(this);

            foreach (CompilerModel model in root.Models)
                model.Accept(this);

            return null;

        }

        public override object Visit(CompilerModel model)
        {

            if (string.IsNullOrEmpty(model.Name))
                Add(model, "Name", "property Name must be Specified");

            foreach (CompilerProperty prop in model.Properties)
                prop.Accept(this);

            return null;

        }

        public override object Visit(CompilerProperty property)
        {

            if (string.IsNullOrEmpty(property.Name))
                Add(property, "Name", "property Name must be Specified");

            return null;

        }

        protected void Add(CompilerBase model, string name, string message)
        {

            var diagnostic = new CompilerBaseDiagnostic()
            {
                LineNumber = model.LineNumber,
                LinePosition = model.LinePosition,
                Name = name,
                Message = message,
            };

            _items.Add(diagnostic);

        }

        public IEnumerable<CompilerBaseDiagnostic> Dignostics => _items;

        private readonly List<CompilerBaseDiagnostic> _items;

    }

}