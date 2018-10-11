using Bb.Core.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.BusinessRule.Models
{

    /// <summary>
    /// Abstract implementation of data service
    /// </summary>
    public abstract class ExtendedDataService
    {

        public ExtendedDataService(string name = null)
        {

            Type myType = GetType();

            var methods = this.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(c => c.DeclaringType == myType)
                .ToArray()
                ;

            if (methods.Length > 1)
                throw new AmbiguousMatchException("Only one method must be public. If you have more of one implementation query, please create another implementation of ExtendedDataService");

            this._method = methods[0];

            if (this._method.GetParameters().Any(c => c.IsOut))
                throw new NotImplementedException("Implementation method can't have out way parameter.");

            if (this._method.GetParameters().Any(c => c.IsOptional))
                throw new NotImplementedException("Implementation method can't have optional parameter.");

            if (this._method.GetParameters().Any(c => c.ParameterType.IsByRef))
                throw new NotImplementedException("Implementation method can't have ref parameter.");

            this.Arguments = this._method.GetParameters().Select(c => new KeyValuePair<string, Type>(c.Name, c.ParameterType)).ToArray();

            this._call = new Lazy<Func<Dictionary<string, object>, object>>(this.Compile());

            this.Key = name ?? this._method.Name;

        }

        /// <summary>
        /// Key service must be used for calling in the provider
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// return expected arguments of the method
        /// </summary>
        public KeyValuePair<string, Type>[] Arguments { get; }


        internal object GetDatas(Dictionary<string, object> properties)
        {
            return this._call.Value(properties);
        }

        private Func<Dictionary<string, object>, object> Compile()
        {

            ParameterExpression arg = Expression.Parameter(typeof(Dictionary<string, object>), "arg");

            var call = this._method.MatchDictionaryOnMethodParameters(Expression.Constant(this), arg, true);

            var ldb = Expression.Lambda<Func<Dictionary<string, object>, object>>(call, arg);

            return ldb.Compile();

        }

        private readonly MethodInfo _method;
        private readonly Lazy<Func<Dictionary<string, object>, object>> _call;

    }

}