using Bb.Compilers.Models;
using Bb.Compilers.Pocos;

namespace Bb.Compilers
{

    public class CompilerModelTranslatorVisitor : CompilerBaseVisitor
    {

        public CompilerModelTranslatorVisitor(PocoModelRepository repository)
        {
            _repository = repository;
        }

        public override object Visit(CompilerModelRoot root)
        {

            var mdl = new PocoModel()
            {
                Name = root.Name,
                BaseName = root.BaseName,
                Description = root.Description,
            };

            foreach (var item in root.Models)
                _repository.Add((PocoModel)item.Accept(this));

            foreach (var property in root.Properties)
                mdl.Properties.Add(new PocoProperty() { Description = property.Description, IsArray = property.IsArray, Name = property.Name, Type = property.Type, });

            _repository.Add(mdl);
            
            return mdl;

        }

        public override object Visit(CompilerModel model)
        {

            var mdl = new PocoModel()
            {
                Name = model.Name,
                Description = model.Description,
                BaseName = model.BaseName,
            };

            foreach (var property in model.Properties)
                mdl.Properties.Add((PocoProperty)property.Accept(this));

            return mdl;

        }


        public override object Visit(CompilerProperty property)
        {

            return new PocoProperty()
            {
                Description = property.Description,
                IsArray = property.IsArray,
                Name = property.Name,
                Type = property.Type,
            };

        }


        protected readonly PocoModelRepository _repository;

    }


}
