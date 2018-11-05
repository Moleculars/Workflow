using Bb.Core;
using Bb.Core.Documents;
using Bb.Workflow.Service.Configurations;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bb.Workflow.Service.Models.Maps
{

    /// <summary>
    /// MdlConfigurationWkDomain extensions
    /// </summary>
    public static class MdlConfigurationWkDomainExtensions
    {


        /// <summary>
        /// Selects the domain version.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static ConfigurationModelContext SelectDomainVersion(this ConfigurationModelContext self)
        {

            foreach (var domain in self.ConfigurationList)
                foreach (var version in domain.Versions)
                    if (version.Types.Any())
                    {
                        self.SelectedDomain = domain.Name;
                        self.SelectedVersion = version.Name;
                        return self;
                    }

            return self;

        }


        /// <summary>
        /// Map IEnumerable of domain
        /// </summary>
        /// <param name="domains">The domains.</param>
        /// <param name="_domain">The domain.</param>
        /// <param name="_version">The version.</param>
        /// <returns></returns>
        public static List<MdlConfigurationWkDomain> Maps(this IEnumerable<IDomainConfiguration> domains, string _domain, string _version)
        {

            List<MdlConfigurationWkDomain> result = new List<MdlConfigurationWkDomain>();

            if (string.IsNullOrEmpty(_domain))
                _domain = domains.FirstOrDefault()?.Name ?? string.Empty;

            foreach (var domain in domains)
            {
                bool dom = domain.Name == _domain;
                result.Add(domain.Map(dom, _version));
            }
            return result;

        }

        /// <summary>
        /// Map one domain
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="_domain">The domain.</param>
        /// <param name="_version">The version.</param>
        /// <returns></returns>
        public static MdlConfigurationWkDomain Map(this IDomainConfiguration domain, bool _domain, string _version)
        {

            MdlConfigurationWkDomain workflows = new MdlConfigurationWkDomain()
            {
                Name = domain.Name
            };

            foreach (MdlConfigurationWkDomainVersion version in domain.GetVersions().Maps(_domain, _version))
                workflows.Versions.Add(version);

            return workflows;

        }

        private static IEnumerable<MdlConfigurationWkDomainVersion> Maps(this IEnumerable<IConfigurationVersion> versions, bool dom, string _version)
        {

            if (string.IsNullOrEmpty(_version))
                _version = versions.FirstOrDefault()?.Name ?? string.Empty;

            foreach (var version in versions)
                if (dom && version.Name == _version)
                    yield return version.MapWithFiles();
                else
                    yield return version.Map();

        }

        /// <summary>
        /// Map IEnumerable
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static MdlConfigurationWkDomainVersion Map(this IConfigurationVersion version)
        {

            return new MdlConfigurationWkDomainVersion()
            {
                Name = version.Name,
                Domain = version.Parent.Name
            };

        }


        /// <summary>
        /// Map IConfigurationVersion in model for site
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static MdlConfigurationWkDomainVersion MapWithFiles(this IConfigurationVersion version)
        {

            MdlConfigurationWkDomainVersion result = version.Map();

            Dictionary<string, MdlConfigurationWkDomainVersionFileByType> _dic = new Dictionary<string, MdlConfigurationWkDomainVersionFileByType>();

            foreach (TypeConfiguration typeConfig in version.Parent.Parent.Types)
                GetList(_dic, typeConfig);

            foreach (IConfigurationDocument file in version.Documents)
            {


                MdlConfigurationWkDomainVersionFileByType type = GetList(_dic, file.TypeConfiguration);

                if (type != null)
                {

                    type.Files.Add(new MdlConfigurationWkDomainVersionFile()
                    {
                        Name = file.Name,
                        Type = file.TypeConfiguration.Extension,
                        CreationDate = file.CreationDate,
                        LastUpdate = file.LastUpdate,
                        TypeConfiguration = file.TypeConfiguration,
                    });

                }
                else
                    Trace.WriteLine($"the extension {file.TypeConfiguration.Extension} can resolve the configuration type");

            }

            foreach (var item in _dic)
                result.Types.Add(item.Value);

            return result;

        }

        /// <summary>
        /// Gets the list of files grouped by type of file.
        /// </summary>
        /// <param name="_dic">The dic.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private static MdlConfigurationWkDomainVersionFileByType GetList(Dictionary<string, MdlConfigurationWkDomainVersionFileByType> _dic, TypeConfiguration type)
        {

            if (!_dic.TryGetValue(type.Name, out MdlConfigurationWkDomainVersionFileByType _type))
                _dic.Add(type.Name, _type = new MdlConfigurationWkDomainVersionFileByType() { Type = type.Name, ConfigurationType = type });

            return _type;

        }
    }

}


