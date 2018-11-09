using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;

namespace Bb.Mappings.Models
{
    public class MappingConfigurationVerbatim
    {

        public MappingConfigurationVerbatim(IFactory<object> factory)
        {
            Maps = new List<MappingConfigurationVerbatimItem>();
            this._factory = factory;
        }

        public Type Source { get; internal set; }
        public Type Target { get; internal set; }
        internal List<MappingConfigurationVerbatimItem> Maps { get; }

        private readonly IFactory<object> _factory;

        public object Map(object source, object target)
        {

            if (target == null)
                target = this._factory.Create();

            foreach (MappingConfigurationVerbatimItem map in Maps)
                map.Map(source, target);

            return target;

        }

    }

}
