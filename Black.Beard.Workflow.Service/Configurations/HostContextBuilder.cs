using System;

namespace Bb.Workflow.Service.Configurations
{

    /// <summary>
    /// Host conctext configuration builder
    /// </summary>
    public class HostContextBuilder
    {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="path"></param>
        public HostContextBuilder(string path)
        {

            ConfigurationPath = path;

        }

        /// <summary>
        /// Configuration path
        /// </summary>
        public string ConfigurationPath { get; }

        /// <summary>
        /// Workflow configuration
        /// </summary>
        public IConfigurationProvider WorkflowConfiguration { get; internal set; }

        /// <summary>
        /// Create a custom context vor every call
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public HostContext CreateLocalContext(IServiceProvider serviceProvider)
        {
            return new HostContext()
            {
                WorkflowConfiguration = this.WorkflowConfiguration,
            };
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class HostContext
    {

        /// <summary>
        /// Workflow configuration
        /// </summary>
        public IConfigurationProvider WorkflowConfiguration { get; internal set; }

    }

}
