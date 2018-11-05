using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Core.Documents
{

    public interface IConfigurationVersion
    {

        IDomainConfiguration Parent { get; }

        string Name { get; set; }

        bool IsDirty { get; set; }

        /// <summary>
        /// Compiles the configuration in the specified path.
        /// </summary>
        ConfigurationCompileResult Compile();

        DateTimeOffset LastUpdate { get; set; }

        IEnumerable<IConfigurationDocument> Documents { get; }

        /// <summary>
        /// Saves the file for type name and name file.
        /// </summary>
        /// <param name="typeName">The type.</param>
        /// <param name="name">The name.</param>
        /// <param name="stringBuilder">The string builder.</param>
        /// <returns></returns>
        List<CheckResult> SaveFile(string typeName, string name, StringBuilder stringBuilder);

        /// <summary>
        /// Gets the file by name and type name.
        /// </summary>
        /// <param name="typeName">The type.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IConfigurationDocument GetFile(string typeName, string name);

    }

}
