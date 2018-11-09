using Bb.Compilers.Models;
using Bb.Compilers.Pocos;
using Bb.ComponentModel.Attributes;
using Bb.Core;

namespace Bb.BusinessRule.Configurations
{

    public static class IncomingConfigurationExtensions
    {

        /// <summary>
        /// Appends the configuration in specified repository.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="domain">The domain.</param>
        /// <param name="version">The version.</param>
        public static void Append(this CompilerModelRoot model, PocoModelRepository repository, string domain, string version)
        {
            IncomingCompilerVisitor visitor = new IncomingCompilerVisitor(repository, domain, version);
            visitor.Visit(model);
        }
    
    }


}
