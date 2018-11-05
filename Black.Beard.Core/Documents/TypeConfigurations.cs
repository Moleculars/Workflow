using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bb.Core.Documents
{
    public class TypeConfigurations : IEnumerable<TypeConfiguration>
    {

        private readonly Dictionary<string, TypeConfiguration> _dicByName;
        private readonly Dictionary<string, TypeConfiguration> _dicByExtension;

        public TypeConfigurations(params TypeConfiguration[] types)
        {

            _dicByName = new Dictionary<string, TypeConfiguration>();
            _dicByExtension = new Dictionary<string, TypeConfiguration>();

            foreach (var type in types)
            {
                _dicByName.Add(type.Name, type);
                _dicByExtension.Add(type.Extension.ToLowerInvariant(), type);
            }

        }

        /// <summary>
        /// Adds the specified template in the list.
        /// </summary>
        /// <param name="template">The template.</param>
        public void Add(IConfigurationTemplateFile template)
        {
            var t = template.Type.ToLowerInvariant();

            var u = GetByExtension(t);
            if (u == null)
            {
                Trace.WriteLine($"the template {template.Name} can'tbe matched with a configuration type");
                return;
            }

            u.Add(template);
        }

        /// <summary>
        /// Gets the configuration of the type by specified name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public TypeConfiguration GetByName(string name)
        {

            if (!_dicByName.TryGetValue(name, out TypeConfiguration type))
                Trace.WriteLine($"the name {name} can resolve the configuration type");

            return type;

        }

        /// <summary>
        /// Gets the configuration of the type by specified extension.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public TypeConfiguration GetByExtension(string type)
        {

            if (!_dicByExtension.TryGetValue(type.ToLowerInvariant(), out TypeConfiguration _type))
                Trace.WriteLine($"the extension {type} can resolve the configuration type");

            return _type;
        }

        public IEnumerator<TypeConfiguration> GetEnumerator()
        {
            return _dicByName.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dicByName.Values.GetEnumerator();
        }

    }

}
