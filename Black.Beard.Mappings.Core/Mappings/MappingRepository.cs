using Bb.ComponentModel.Accessors;
using Bb.ComponentModel.Factories;
using Bb.Core.Documents;
using System;
using System.Collections.Generic;

namespace Bb.Mappings.Models
{

    public class MappingRepository
    {

        public MappingRepository()
        {
            _factoryProvider = new FactoryProvider();
            _maps = new Dictionary<Tuple<Type, Type>, MappingConfigurationVerbatim>();
        }

        public void Append(MappingConfiguration model, string name, Type source, Type target)
        {

            var result = new MappingConfigurationVerbatim(_factoryProvider.CreateFrom<object>(target))
            {
                Source = source,
                Target = target,
            };

            foreach (MappingItemConfiguration mapping in model.Mappings)
            {

                var verbatim = new MappingConfigurationVerbatimItem()
                {
                    Source = ResolvePath(mapping.SourcePath, source, "source", name),
                    Target = ResolvePath(mapping.TargetPath, target, "target", name),
                };

                result.Maps.Add(verbatim);

            }

            _maps.Add(Tuple.Create(source, target), result);

        }

        public object ChangeType(object source, Type target)
        {
            var mapper = GetMapper(source.GetType(), target);
            return mapper.Map(source, null);
        }

        public MappingConfigurationVerbatim GetMapper(Type source, Type target)
        {

            if (_maps.TryGetValue(Tuple.Create(source, target), out MappingConfigurationVerbatim result))
                return result;

            return null;

        }

        private MappedPropertyPath ResolvePath(PropertyPath path, Type model, string way, string name)
        {

            string propertyName = path.Name;

            MappedPropertyPath result = new MappedPropertyPath()
            {
                Model = model,
                Name = propertyName,
                Root = this,
                FactoryProvider = _factoryProvider,
            };

            var properties = AccessorItem.Get(model, true);

            result.Property = properties[propertyName];

            if (result.Property == null)
            {
                Add(new CheckResult()
                {
                    Document = name,
                    Message = $"{way} property name {propertyName} can't be resolved",
                    Name = propertyName,
                    Severity = "Error",
                    LineNumber = 0,
                    LinePosition = 0,
                });

                return null;

            }

            var type = result.Property.Type;

            if (type.IsPrimitive || type.IsEnum || type == typeof(String)) // reference repository of object
            {

            }
            else
            {

                if (path.Sub == null)
                {
                    Add(new CheckResult()
                    {
                        Document = name,
                        Message = $"type {result.Property.Type} of property {propertyName} can't be mapped without mapper",
                        Name = propertyName,
                        Severity = "Error",
                        LineNumber = 0,
                        LinePosition = 0,
                    });

                    return null;

                }

                var s = ResolvePath(path.Sub, result.Property.Type, way, name);

                if (s == null)
                    return null;

                result.Sub = s;

            }

            return result;

        }

        private void Add(CheckResult checkResult)
        {

        }

        private readonly FactoryProvider _factoryProvider;
        private readonly Dictionary<Tuple<Type, Type>, MappingConfigurationVerbatim> _maps;

    }

}
