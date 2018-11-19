using Bb.Core.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.BusinessRule.Models
{

    public class ExtendedDataServiceProvider : IEnumerable<ExtendedDataService>
    {

        /// <summary>
        /// ctor
        /// </summary>
        public ExtendedDataServiceProvider(ComponentModel.TypeReferential typeReferential, bool  autoDetect = false)
        {
            _services = new Dictionary<string, ExtendedDataService>();
            if (autoDetect)
                Append(new ExtendedDataServiceResolver(typeReferential).ToArray());
        }

        /// <summary>
        /// Append data services
        /// </summary>
        /// <param name="extendedDataServices"></param>
        public void Append(params ExtendedDataService[] extendedDataServices)
        {
            if (extendedDataServices != null)
                foreach (ExtendedDataService extendedDataService in extendedDataServices)
                    _services.Add(extendedDataService.Key, extendedDataService);
        }

        /// <summary>
        /// Call data service with specified arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceKey"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public object GetDatas<T>(string serviceKey, T arguments)
        {

            if (this._services.TryGetValue(serviceKey, out ExtendedDataService service))
            {
                Dictionary<string, object> properties = arguments.GetDictionnaryProperties();
                return service.GetDatas(properties);
            }

            throw new NotImplementedException(serviceKey);

        }

        /// <summary>
        /// Call data service with specified arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceKey"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public object GetDatas(string serviceKey, Dictionary<string, object> arguments)
        {

            if (this._services.TryGetValue(serviceKey, out ExtendedDataService service))
                return service.GetDatas(arguments);

            throw new NotImplementedException(serviceKey);

        }

        public IEnumerator<ExtendedDataService> GetEnumerator() { return this._services.Values.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this._services.Values.GetEnumerator(); }


        private Dictionary<string, ExtendedDataService> _services;

    }
}
