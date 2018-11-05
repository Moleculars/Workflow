using Bb.Core.Documents;
using System;

namespace Bb.Workflow.Configurations.Documents
{
    public abstract class MemoryConfigurationDocumentTemplate : IConfigurationTemplateFile
    {

        public abstract string Name { get; }

        public abstract string Type { get; }

        public abstract DateTimeOffset CreationDate { get; }

        public abstract DateTimeOffset LastUpdate { get; }

        public abstract string Content { get; }

    }

}
