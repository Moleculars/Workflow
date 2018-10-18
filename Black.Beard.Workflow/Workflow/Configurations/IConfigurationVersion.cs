using System;
using System.Collections.Generic;

namespace Bb.Workflow
{
    public interface IConfigurationVersion
    {

        IDomainConfiguration Parent { get; }

        string Name { get; set; }

        bool IsDirty { get; set; }

        DateTime LastUpdate { get; set; }

        IEnumerable<IConfigurationFile> Files { get; }

    }

}
