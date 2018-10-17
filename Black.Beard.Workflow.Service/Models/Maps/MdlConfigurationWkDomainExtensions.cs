using Bb.Workflow.Service.Configurations;
using System.Collections.Generic;
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
        /// Map IEnumerable
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static MdlConfigurationWkDomainVersion MapWithFiles(this IConfigurationVersion version)
        {

            MdlConfigurationWkDomainVersion result = version.Map();

            Dictionary<string, MdlConfigurationWkDomainVersionFileByType> _dic = new Dictionary<string, MdlConfigurationWkDomainVersionFileByType>();

            foreach (var item in ConfigurationExtensions.AvailableExtensions)
                GetList(_dic, item);

            foreach (IConfigurationFile file in version.Files)
            {

                MdlConfigurationWkDomainVersionFileByType type = GetList(_dic, file.Type);

                type.Files.Add(new MdlConfigurationWkDomainVersionFile()
                {
                    Name = file.Name,
                    Type = file.Type,
                    Path = file.Path,
                    CreationDate = file.CreationDate,
                    LastUpdate = file.LastUpdate,
                });

            }

            foreach (var item in _dic)
                result.Types.Add(item.Value);

            return result;

        }

        private static MdlConfigurationWkDomainVersionFileByType GetList(Dictionary<string, MdlConfigurationWkDomainVersionFileByType> _dic, string typeName)
        {

            if (!_dic.TryGetValue(typeName, out MdlConfigurationWkDomainVersionFileByType type))
                _dic.Add(typeName, type = new MdlConfigurationWkDomainVersionFileByType() { Type = typeName });

            return type;

        }
    }

}


