using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Permet de retourner la liste des methodes d'evaluation disponibles dans les types fournis.
    /// </summary>
    public static class MethodDiscovery
    {

        /// <summary>
        /// Permet de retourner la liste des methodes d'evaluation disponibles dans les types fournis.
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static Dictionary<string, BusinessAction<T>> GetActions<T>(ComponentModel.TypeReferential typeReferential, bool startWith, Type returnType, params Type[] MethodSign) //where T : Context
        {

            if (returnType == null)
                throw new ArgumentNullException(nameof(returnType));

            var result = new Dictionary<string, BusinessAction<T>>();

            var types = typeReferential.GetTypes(typeof(IMethodDiscovery));

            foreach (var type in types)
            {
                IMethodDiscovery methodDiscovery = Activator.CreateInstance(type, new object[] { startWith }) as IMethodDiscovery;
                foreach (var action in methodDiscovery.GetActions<T>(returnType, MethodSign))
                {
                    if (result.ContainsKey(action.RuleName))
                        Trace.WriteLine($"duplicate rule '{action.RuleName}' in {action.Origin}");
                    else
                        result.Add(action.RuleName, action);
                }
            }

            return result;

        }

    }
}