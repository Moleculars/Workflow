using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Core
{
    public class CompileContext
    {

        public CompileContext(string domain, string version)
        {
            this.Domain = domain;
            this.Version = version;

            this.IncomingModels = new List<string>();
            this.StateModels = new List<string>();

        }

        public string Domain { get; }

        public string Version { get; }

        public object Repository { get; set; }

        public List<string> IncomingModels { get; }

        public List<string> StateModels { get; }


    }
}
