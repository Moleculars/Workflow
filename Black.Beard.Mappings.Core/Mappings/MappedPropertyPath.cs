using Bb.ComponentModel.Accessors;
using Bb.ComponentModel.Factories;
using System;

namespace Bb.Mappings.Models
{
    public class MappedPropertyPath
    {

        internal object Create()
        {

            if (_factory == null)
                _factory = FactoryProvider.CreateFrom<object>(Property.Type);

            return _factory.Create();

        }

        public string Name { get; internal set; }
        public MappedPropertyPath Sub { get; internal set; }
        public AccessorItem Property { get; internal set; }
        public Type Model { get; internal set; }
        public MappingRepository Root { get; internal set; }
        public FactoryProvider FactoryProvider { get; internal set; }

        private IFactory<object> _factory;


    }

}


        //public object Get(object instance)
        //{
        //    var value = Property.GetValue(instance);

        //    if (Sub != null)
        //        value = Sub.Get(value);

        //    return value;

        //}

        //public void Set(object instance, object value)
        //{

        //    if (Sub != null)
        //    {

        //        var subInstance = Property.GetValue(instance);

        //        if (subInstance == null)
        //        {
        //            subInstance = Create();
        //            Property.SetValue(instance, subInstance);
        //        }

        //        Sub.Set(subInstance, value);

        //    }
        //    else
        //    {
        //        if (value != null && value.GetType() != Property.Type)
        //            value = Convert.ChangeType(value, Property.Type);

        //        Property.SetValue(instance, value);

        //    }

        //}