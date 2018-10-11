
using System;
using System.Diagnostics;
using Pssa.Routing.Services.Core.Audits;

namespace Pssa.Routing.Services.Core.Chain
{
    public class AlternativeChain<TContext> : ResponsabilityChain<TContext> where TContext : Context
    {

        public AlternativeChain(string name, bool enabled, Func<TContext, bool> func) : base(name, enabled, func)
        {
        }

        public override bool Evaluate(TContext item)
        {

            var result = base.Evaluate(item);

            //Trace.WriteLine($"rule: {Name} \tresult: {result} \t\tcolis: {item.Parcel.Id}\tpudo: {item.Pudo.SiteInternationalId}");
            item.AuditParcel.ChainSteps.Add(new ChainStep
            {
                ChainName = Name,
                ResultChain = result
            });

            if (NextCommandOnSuccess == null || NextCommandOnFail == null)
                return result;

            return result
                ? NextCommandOnSuccess.Evaluate(item)
                : NextCommandOnFail.Evaluate(item);

        }

        public Command<TContext> NextCommandOnSuccess { get; set; }

        public Command<TContext> NextCommandOnFail { get; set; }

    }
}