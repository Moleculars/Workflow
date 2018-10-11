using Pssa.Workflow;
using System;
using System.Collections.Generic;
using System.IO;

namespace Black.Beard.Workflow.Service.Configurations
{

    public class LocalStorageConfigurationProvider : IConfigurationProvider
    {

        public LocalStorageConfigurationProvider(DirectoryInfo path)
        {

            foreach (DirectoryInfo globalConfiguration in path.GetDirectories())
            {

                LocalStorageGlobalConfiguration config = new LocalStorageGlobalConfiguration(this, globalConfiguration.Name);

            }

        }

        public IEnumerable<IGlobalConfiguration> GetConfigurations()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<StringBuilder> GetConfigurations(string name)
        //{
        //    throw new NotImplementedException();
        //}


    }


    public class LocalStorageGlobalConfiguration : IGlobalConfiguration
    {

        public LocalStorageGlobalConfiguration(IConfigurationProvider configurationProvider, string name)
        {
            Parent = configurationProvider;
            Name = name;
        }

        public IConfigurationProvider Parent { get; }

        public string Name { get; set; }

    }


}
