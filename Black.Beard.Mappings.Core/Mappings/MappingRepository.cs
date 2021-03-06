﻿using Bb.Compilers.Pocos;
using Bb.ComponentModel;
using Bb.ComponentModel.Accessors;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Factories;
using Bb.Core.Documents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Mappings.Models
{

    public class MappingRepository
    {

        public MappingRepository(TypeReferential typeReferential)
        {
            this._typeReferential = typeReferential;
            _factoryProvider = new FactoryProvider();
            _maps = new Dictionary<Tuple<Type, Type>, MappingConfigurationVerbatim>();
            _chekResults = new List<CheckResult>();

        }

        /// <summary>
        /// Resolves the types of the model by names.
        /// </summary>
        /// <param name="typeResolver">The type resolver.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public (Type, Type) ResolveTypes(MappingConfiguration model)
        {
            
            if (string.IsNullOrEmpty(model.SourceType))
                throw new NullReferenceException(nameof(model.SourceType));

            var types = _typeReferential.GetTypesWithAttributes(typeof(ExposeModel));

            foreach (var item in types)
            {
                var attribute = item.CustomAttributes.OfType<ExposeModel>().First();
            }


            if (model.SourceType == null)
            {

            }

            Type source = _typeReferential.ResolveByName(model.SourceType);




            if (string.IsNullOrEmpty(model.TargetType))
                throw new NullReferenceException(nameof(model.TargetType));

            if (model.TargetType == null)
            {

            }

            Type target = _typeReferential.ResolveByName(model.TargetType);

            return (source, target);

        }

        public void Append(MappingConfiguration[] models)
        {
            foreach (var model in models)
            {
                var types = ResolveTypes(model);
                Append(model, $"C_{types.Item1.Name}{types.Item2.Name}", types.Item1, types.Item2);
            }

        }

        public MappingConfigurationVerbatim Append(MappingConfiguration model, string name, Type source, Type target)
        {

            bool isNew = false;
            var result = GetMapper(source, target);
            if (result == null)
            {
                result = new MappingConfigurationVerbatim(_factoryProvider.CreateFrom<object>(target))
                {
                    Source = source,
                    Target = target,
                };
                isNew = true;
            }


            if (model != null) // can be null if it is just an initialization
            {

                var sourceProperties = AccessorItem.Get(source, true);
                var targetProperties = AccessorItem.Get(target, true);

                foreach (MappingItemConfiguration mapping in model.Mappings)
                {

                    var verbatim = new MappingConfigurationVerbatimItem()
                    {
                        Source = ResolvePath(mapping.SourcePath, source, sourceProperties, "source", name),
                        Target = ResolvePath(mapping.TargetPath, target, targetProperties, "target", name),
                        Parent = this,
                    };

                    if (verbatim.Source == null && verbatim.Target == null)
                    {
                        var psource = sourceProperties[mapping.SourcePath.Name];
                        var ptarget = targetProperties[mapping.TargetPath.Name];
                        if (psource != null && ptarget != null)
                        {

                            verbatim.Source = new MappedPropertyPath()
                            {
                                Model = source,
                                Name = mapping.SourcePath.Name,
                                Root = this,
                                FactoryProvider = _factoryProvider,
                                Property = psource
                            };

                            verbatim.Target = new MappedPropertyPath()
                            {
                                Model = target,
                                Name = mapping.TargetPath.Name,
                                Root = this,
                                FactoryProvider = _factoryProvider,
                                Property = ptarget
                            };

                            verbatim.Mapper = GetMapper(psource.Type, ptarget.Type);
                            if (verbatim.Mapper == null)
                                verbatim.Mapper = Append(null, null, psource.Type, ptarget.Type); // it is just an initialization

                            result.Maps.Add(verbatim);

                        }

                    }
                    else
                        result.Maps.Add(verbatim);

                }
            }

            if (isNew)
                _maps.Add(Tuple.Create(source, target), result);

            return result;

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

        private MappedPropertyPath ResolvePath(PropertyPath path, Type model, AccessorList properties, string way, string name)
        {

            string propertyName = path.Name;

            MappedPropertyPath result = new MappedPropertyPath()
            {
                Model = model,
                Name = propertyName,
                Root = this,
                FactoryProvider = _factoryProvider,
            };

            result.Property = properties[propertyName];

            if (result.Property == null)
            {
                Add(new CheckResult()
                {
                    Document = name,
                    Message = $"{way} property name {propertyName} can't be resolved",
                    Name = propertyName,
                    Severity = SeverityEnum.Error,
                    LineNumber = path.GetLineNumber(),
                    LinePosition = path.GetLinePosition(),
                });

                return null;

            }

            var type = result.Property.Type;

            if (IncludeBaseType(type)) // reference repository of object
            {

            }
            else
            {

                if (path.Sub == null)
                    return null;

                var properties2 = AccessorItem.Get(result.Property.Type, true);
                var s = ResolvePath(path.Sub, result.Property.Type, properties2, way, name);

                if (s == null)
                    return null;

                result.Sub = s;

            }

            return result;

        }

        private static bool IncludeBaseType(string typeName)
        {
            Type type = Type.GetType(typeName);
            if (type != null)
                return IncludeBaseType(type);

            return type.IsPrimitive || type.IsEnum || type == typeof(String);

        }

        private static bool IncludeBaseType(Type type)
        {
            return type.IsPrimitive || type.IsEnum || type == typeof(String);
        }

        private void Add(CheckResult checkResult)
        {
            _chekResults.Add(checkResult);
        }

        public IEnumerable<CheckResult> ChekResults => _chekResults;

        /// <summary>
        /// Find all mapping by name convention.
        /// The models found are not added in repository
        /// </summary>
        /// <param name="tuples">The tuples.</param>
        /// <returns></returns>
        public MappingConfiguration[] InitializeAndCollectByName(params (PocoModel, PocoModel)[] tuples)
        {

            List<MappingConfiguration> results = new List<MappingConfiguration>();

            var noDoublon = new HashSet<Tuple<PocoModel, PocoModel>>() { };
            var modelsToProcess = new Queue<System.Tuple<PocoModel, PocoModel>>();
            var hashCollector = new HashSet<System.Tuple<PocoModel, PocoModel>>();

            foreach ((PocoModel, PocoModel) tuple in tuples)
            {
                var t = tuple.ToTuple();
                noDoublon.Add(t);
                modelsToProcess.Enqueue(t);
            }

            while (modelsToProcess.Count > 0)
            {

                var t = modelsToProcess.Dequeue();
                hashCollector.Clear();

                results.Add(InitializeAndCollectByName(t.Item1, t.Item2, hashCollector));

                foreach (var item in hashCollector)
                    if (noDoublon.Add(item))
                        modelsToProcess.Enqueue(item);

            }

            return results.ToArray();

        }

        /// <summary>
        /// Find all mapping by name convention
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="toGenerate">To generate.</param>
        /// <returns></returns>
        private MappingConfiguration InitializeAndCollectByName(PocoModel sourceType, PocoModel targetType, HashSet<Tuple<PocoModel, PocoModel>> toGenerate)
        {

            var result = new MappingConfiguration()
            {
                SourceType = sourceType.Name,
                TargetType = targetType.Name,
                //SourceType = $"{sourceType.Assembly.GetName().Name}, {sourceType.Namespace}.{sourceType.Name}",
                //TargetType = $"{targetType.Assembly.GetName().Name}, {targetType.Namespace}.{targetType.Name}",
            };

            foreach (var propertySource in targetType.Properties)
            {

                var propertyTarget = targetType.Properties.FirstOrDefault(c => c.Name == propertySource.Name);
                if (propertyTarget != null)
                {
                    var t1 = IncludeBaseType(propertySource.Type);
                    var t2 = IncludeBaseType(propertyTarget.Type);

                    if (t1 && t2)
                    {
                        result.Mappings.Add(new MappingItemConfiguration()
                        {
                            SourcePath = new PropertyPath() { Name = propertySource.Name },
                            TargetPath = new PropertyPath() { Name = propertyTarget.Name },
                        });
                    }
                    else if (!t1 && !t2)
                    {
                        result.Mappings.Add(new MappingItemConfiguration()
                        {
                            SourcePath = new PropertyPath() { Name = propertySource.Name },
                            TargetPath = new PropertyPath() { Name = propertyTarget.Name },
                        });

                        //toGenerate.Add(Tuple.Create(propertySource.Type, propertyTarget.Type));

                    }
                }
            }

            return result;

        }


        /// <summary>
        /// resolve configuration by name convention
        /// The models found are not added in repository
        /// </summary>
        /// <param name="tuples">The tuples.</param>
        /// <returns></returns>
        public static MappingConfiguration[] InitializeAndCollectByName(params (Type, Type)[] tuples)
        {

            List<MappingConfiguration> results = new List<MappingConfiguration>();

            var noDoublon = new HashSet<Tuple<Type, Type>>() { };
            var modelsToProcess = new Queue<System.Tuple<System.Type, System.Type>>();
            var hashCollector = new HashSet<System.Tuple<System.Type, System.Type>>();

            foreach ((Type, Type) tuple in tuples)
            {
                var t = tuple.ToTuple();
                noDoublon.Add(t);
                modelsToProcess.Enqueue(t);
            }

            while (modelsToProcess.Count > 0)
            {

                var t = modelsToProcess.Dequeue();
                hashCollector.Clear();

                results.Add(InitializeAndCollectByName(t.Item1, t.Item2, hashCollector));

                foreach (var item in hashCollector)
                    if (noDoublon.Add(item))
                        modelsToProcess.Enqueue(item);

            }

            return results.ToArray();

        }

        private static MappingConfiguration InitializeAndCollectByName(Type sourceType, Type targetType, HashSet<Tuple<Type, Type>> toGenerate)
        {

            var result = new MappingConfiguration()
            {
                SourceType = $"{sourceType.Assembly.GetName().Name}, {sourceType.Namespace}.{sourceType.Name}",
                TargetType = $"{targetType.Assembly.GetName().Name}, {targetType.Namespace}.{targetType.Name}",
            };

            var sourceProperties = AccessorItem.Get(sourceType, true);
            var targetProperties = AccessorItem.Get(targetType, true);

            foreach (var propertySource in targetProperties)
            {

                var propertyTarget = targetProperties[propertySource.Name];
                if (propertyTarget != null)
                {

                    if (IncludeBaseType(propertyTarget.Type) && IncludeBaseType(propertyTarget.Type))
                    {
                        result.Mappings.Add(new MappingItemConfiguration()
                        {
                            SourcePath = new PropertyPath() { Name = propertySource.Name },
                            TargetPath = new PropertyPath() { Name = propertyTarget.Name },
                        });
                    }
                    else if (!IncludeBaseType(propertyTarget.Type) && !IncludeBaseType(propertyTarget.Type))
                    {
                        result.Mappings.Add(new MappingItemConfiguration()
                        {
                            SourcePath = new PropertyPath() { Name = propertySource.Name },
                            TargetPath = new PropertyPath() { Name = propertyTarget.Name },
                        });
                        toGenerate.Add(Tuple.Create(propertySource.Type, propertyTarget.Type));
                    }
                }
            }

            return result;

        }

        private readonly TypeReferential _typeReferential;
        private readonly FactoryProvider _factoryProvider;
        private readonly Dictionary<Tuple<Type, Type>, MappingConfigurationVerbatim> _maps;
        private readonly List<CheckResult> _chekResults;

    }

}
