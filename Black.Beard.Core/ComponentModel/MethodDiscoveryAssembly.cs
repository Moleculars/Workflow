using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bb.ComponentModel
{

    public class MethodDiscoveryAssembly : IMethodDiscovery
    {


        public MethodDiscoveryAssembly(bool startWith, TypeReferential typeReferential)
        {
            this._typeReferential = typeReferential;
            this._startWith = startWith;
        }

        /// <summary>
        /// Return list of method for the specified arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="returnType"></param>
        /// <param name="methodSign"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">returnType</exception>
        /// <exception cref="ArgumentNullException">methodSign</exception>
        public IEnumerable<BusinessAction<T>> GetActions<T>(Type returnType, params Type[] methodSign) //where T : Context
        {

            this.returnType = returnType ?? throw new ArgumentNullException(nameof(returnType));
            this.methodSign = methodSign ?? throw new ArgumentNullException(nameof(methodSign));

            var types = _typeReferential.GetTypesWithAttributes(typeof(ExposeClassAttribute));
            var actions = this.GetActions_Impl<T>(types.ToArray());
            return actions;
        }

        /// <summary>
        /// Permet de retourner la liste des methodes d'evaluation disponibles dans les types fournis.
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        private IEnumerable<BusinessAction<T>> GetActions_Impl<T>(params Type[] types) //where T : Context
        {

            var _result = new List<BusinessAction<T>>();

            foreach (var type in types)
            {

                var items = this._startWith
                    ? GetStartByMethods(type, this.returnType, methodSign)
                    : GetMethods(type, this.returnType, methodSign)
                    ;

                foreach (var method in items)
                {
                    var attribute = Attribute.GetCustomAttribute(method, typeof(RegisterMethodAttribute)) as RegisterMethodAttribute;
                    if (attribute != null)
                    {

                        ParameterExpression argumentCOntext = Expression.Parameter(typeof(T), "context");

                        _result.Add(new BusinessAction<T>
                        {
                            Method = method,
                            Type = type,
                            RuleName = attribute.DisplayName,
                            Origin = $"Assembly {type.AssemblyQualifiedName}",
                        });
                    }
                }
            }

            return _result;
        }

        /// <summary>
        ///     Return the list of method
        /// </summary>
        /// <param name="type"></param>
        /// <param name="returnType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private IEnumerable<MethodInfo> GetMethods(Type type, Type returnType, params Type[] parameters)
        {

            var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(c => c.ReturnType == returnType).ToList();

            foreach (var item in methods)
            {
                var _parameters = item.GetParameters();
                if (_parameters.Length != parameters.Length)
                    continue;


                for (var i = 0; i < parameters.Length; i++)
                {
                    var _p1 = _parameters[i];
                    var _p2 = parameters[i];
                    if (_p1.ParameterType != _p2)
                        continue;
                }

                yield return item;


            }
        }

        /// <summary>
        /// Return the list of method
        /// </summary>
        /// <param name="type"></param>
        /// <param name="returnType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private IEnumerable<MethodInfo> GetStartByMethods(Type type, Type returnType, params Type[] parameters)
        {

            var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(c => c.ReturnType == returnType).ToList();

            foreach (var item in methods)
            {
                var _parameters = item.GetParameters();
                if (_parameters.Length < parameters.Length)
                    continue;

                for (var i = 0; i < parameters.Length; i++)
                {
                    var _p1 = _parameters[i];
                    var _p2 = parameters[i];
                    if (_p1.ParameterType != _p2)
                        continue;
                }

                yield return item;

            }
        }


        private Type returnType;
        private Type[] methodSign;
        private readonly TypeReferential _typeReferential;
        private readonly bool _startWith;
    }
}
