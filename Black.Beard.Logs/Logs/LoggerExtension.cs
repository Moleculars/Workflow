using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Logs
{
    internal static class LoggerExtension
    {

        /// <summary>
        /// format the serialization of the specified object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">object sour to serialized</param>
        /// <param name="format">output format</param>
        /// <returns>string of the format with the source propertie's serialized</returns>
        public static Dictionary<string, object> GetDictionnaryProperties(this object source, bool ignoreCase = true)
        {
            System.Diagnostics.Contracts.Contract.Requires(!object.Equals(source, null), "null reference exception 'source'");
            return GetPropertiesMethod(source.GetType(), ignoreCase)(source);
        }

        #region Compile object serialization

        /// <summary>
        /// Get compiled method or create
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static Func<object, Dictionary<string, object>> GetPropertiesMethod(Type type, bool ignoreCase)
        {

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (!_funcs.TryGetValue(type, out Func<object, Dictionary<string, object>> result))
                lock (_lock)
                    if (!_funcs.TryGetValue(type, out result))
                        _funcs.Add(type, result = CompileObject(type, ignoreCase));

            return result;

        }

        /// <summary>
        /// Compile method for serialize all properties of the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeSource"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static Func<object, Dictionary<string, object>> CompileObject(Type typeSource, bool ignoreCase)
        {

            Type containerType = typeof(Dictionary<string, object>);
            Type stringType = typeof(string);
            var _properties = typeSource.GetAllProperties().Where(c => c.CanRead);
            var properties = new HashSet<string>();
            var m = containerType.GetNamedMethod("Add", typeof(string), typeof(object));

            // variables
            var parameterIn = Expression.Parameter(typeof(object), "argIn");
            var parameter = Expression.Variable(typeSource, "arg1");
            var dic = Expression.Variable(containerType, "dic");

            var lst = new List<Expression>()
            {
                // var dic = new Dictionary<string, object>();
                dic.CreateObject(),
                parameter.SettedBy(parameterIn.As(typeSource)),

            };

            foreach (PropertyInfo item in _properties)
            {

                var n = item.Name;

                if (ignoreCase)
                    n = n.ToLower();

                if (properties.Add(item.Name))
                {
                    var p = item.PropertyType;
                    var m1 = parameter.Member(item);

                    if (p == typeof(object))
                        lst.Add(dic.Invoke(m, Expression.Constant(n), m1));

                    else
                        lst.Add(dic.Invoke(m, Expression.Constant(n), m1.As(typeof(object))));

                }
            }
            // return builder.ToString();
            lst.Add(dic);

            // Create func
            BlockExpression block = Expression.Block(containerType, new ParameterExpression[] { dic, parameter }, lst);
            var lbd = Expression.Lambda<Func<object, Dictionary<string, object>>>(block, parameterIn);

            return lbd.Compile();

        }

        private static readonly object _lock = new object();

        #endregion Compile object serialization

        #region Expressions

        public static BinaryExpression CreateObject(this Expression self)
        {
            return self.SettedBy(Expression.New(self.Type));
        }

        public static BinaryExpression SettedBy(this Expression self, Expression right)
        {
            return Expression.Assign(self, right);
        }

        public static UnaryExpression As(this Expression self, Type type)
        {
            return Expression.ConvertChecked(self, type);
        }

        public static MemberExpression Member(this Expression self, PropertyInfo property)
        {
            return Expression.Property(self, property);
        }

        public static MethodCallExpression Invoke(this Expression self, MethodInfo method, params Expression[] args)
        {

            if (args.Length == 0)
                return Expression.Call(self, method);

            else
                return Expression.Call(self, method, args);

        }

        public static MethodInfo GetNamedMethod(this Type componentType, string name, params Type[] args)
        {
            if (componentType == null)
                throw new ArgumentNullException(nameof(componentType));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("message", nameof(name));

            var methods = GetAllMethods(componentType)
                //.Where(c => c.IsPublic)
                .ToList();

            foreach (var item in methods.Where(c => c.Name == name))
            {
                var args2 = item.GetParameters();
                if (args.Length == args2.Length)
                {

                    for (int i = 0; i < args.Length; i++)
                        if (args[i] != args2[i].ParameterType)
                            continue;

                    return item;

                }
            }

            return null;

        }

        public static IEnumerable<MethodInfo> GetAllMethods(this Type componentType)
        {

            if (componentType == null)
                throw new ArgumentNullException(nameof(componentType));

            var type = componentType;

            while (type != null && type != typeof(object))
            {

                foreach (var item in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    yield return item;

                type = type.BaseType;

            }
        }

        public static IEnumerable<PropertyInfo> GetAllProperties(this Type componentType)
        {

            if (componentType == null)
                throw new ArgumentNullException(nameof(componentType));

            var type = componentType;

            while (type != null && type != typeof(object))
            {

                foreach (var item in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    yield return item;

                type = type.BaseType;

            }
        }

        #endregion Expressions

        #region private

        private static Dictionary<Type, Func<object, Dictionary<string, object>>> _funcs = new Dictionary<Type, Func<object, Dictionary<string, object>>>();

        #endregion private

    }

}
