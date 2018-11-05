using System;
using System.Collections.Generic;
using Bb.ComponentModel.Accessors;

namespace Bb.Referentiels
{

    internal class ReferentialRow
    {

        public ReferentialRow(object instance)
        {
            this.Instance = instance;

        }

        public object Instance { get; }

    }
}