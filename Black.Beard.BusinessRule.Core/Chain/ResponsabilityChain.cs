using System;
using System.Diagnostics;

namespace Pssa.Routing.Services.Core.Chain
{
    public class ResponsabilityChain<T> : Command<T>
    {

        public ResponsabilityChain(string name, bool enabled, Func<T, bool> func) : base(name, enabled, func)
        {

        }

    }
}