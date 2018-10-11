using System.Collections.Generic;
using System.Text;

namespace Bb.Workflow
{

    public interface IConfigurationProvider
    {

        /// <summary>
        /// Load all configuration in memory
        /// </summary>
        void Initialize();

        /// <summary>
        /// Load one configuration in memory
        /// </summary>
        /// <param name="configurationName"></param>
        void Initialize(string configurationName);

        IEnumerable<IGlobalConfiguration> GetConfigurations();

        //IEnumerable<StringBuilder> GetConfigurations(string name);

    }

    public interface IGlobalConfiguration
    {

        IConfigurationProvider Parent { get; }

        string Name { get; set; }

    }

}
