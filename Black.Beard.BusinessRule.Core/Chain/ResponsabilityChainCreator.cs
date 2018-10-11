using System;
using System.Collections.Generic;
using Pssa.Routing.Services.Core.ComponentModel;
using Pssa.Routing.Services.Core.Configurations;

namespace Pssa.Routing.Services.Core.Chain
{
    public class ResponsabilityChainCreator<T, TContext> 
        where T : AlternativeChain<TContext>
        where TContext : Context
    {

        static ResponsabilityChainCreator()
        {
            // Discover all actions
            Actions = MethodDiscovery.GetActions<TContext>(typeof(bool), typeof(TContext));

        }

        public static T Load(string fileName)
        {

            //var configArborescence = Serializer.LoadFile<ResponsabilityChainParameter>(fileName);
            //var result = RecursiveChainCall(configArborescence);
            //return result;

            return null;

        }

        private static T RecursiveChainCall(ResponsabilityChainParameter chain)
        {

            if (chain.SuccessChain != null != (chain.FailChain != null))
                throw new InvalidOperationException(
                    $"if one way is defined, the two way must defined action on {chain.Name}");

            // On cherche dans les actions répertoriées par le type discovery
            if (!Actions.TryGetValue(chain.Name, out BusinessAction<TContext> act))
                throw new InvalidOperationException(
                    $"action {chain.Name} can't be resolve. Please check name or ensure assembly is accessible");

            var cmd = (AlternativeChain<TContext>)Activator.CreateInstance(typeof(T), new object[] { act.RuleName, chain.Enabled, null /*act.Action*/ });

            if (chain.SuccessChain != null)
            {
                cmd.NextCommandOnSuccess = RecursiveChainCall(chain.SuccessChain);
                cmd.NextCommandOnFail = RecursiveChainCall(chain.FailChain);
            }

            return (T)cmd;

        }
        
        private static readonly Dictionary<string, BusinessAction<TContext>> Actions;

    }
}