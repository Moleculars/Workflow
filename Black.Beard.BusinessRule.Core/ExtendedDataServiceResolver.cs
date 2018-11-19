using Bb.BusinessRule.Models;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.BusinessRule
{

    public class ExtendedDataServiceResolver : IEnumerable<ExtendedDataService>
    {
        private readonly TypeReferential _typeReferential;

        public ExtendedDataServiceResolver(ComponentModel.TypeReferential typeReferential)
        {

            this._typeReferential = typeReferential;

            var types = this._typeReferential
                .GetTypesWithAttributes(
                    typeof(ExtendedDataService), 
                    typeof(ExposeClassAttribute)
                );
       
            this._list = types.Select(type => (ExtendedDataService)Activator.CreateInstance(type, new object[] { })).ToList();

        }

        public List<ExtendedDataService> _list { get; }

        public IEnumerator<ExtendedDataService> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

    }


}
