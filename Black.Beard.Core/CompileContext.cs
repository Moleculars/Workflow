using System;
using System.Collections.Generic;
using System.Text;
using Bb.ComponentModel;
using Black.Beard.Core.Documents;

namespace Bb.Core
{
    public class CompileContext
    {

        public CompileContext(string domain, string version, TypeReferential typeReferential)
        {
            this.Domain = domain;
            this.Version = version;

            this.IncomingModels = new List<string>();
            this.StateModels = new List<string>();

        }

        public string Domain { get; }

        public string Version { get; }

        public object Repository { get; set; }

        public object RepositoryMapping { get; set; }

        
        public List<string> IncomingModels { get; }

        public List<string> StateModels { get; }

        public VersionedConfigurationDocument VersionedConfiguration { get; set; }


    }
}
