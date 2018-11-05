using Bb.ComponentModel.Accessors;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bb.Referentiels
{

    [DebuggerDisplay("{Name}")]
    public class Referential
    {

        static Referential()
        {
            None = new ReferentialIndex() { Name = "None" };
        }

        public Referential()
        {
            _dic = new Dictionary<string, ReferentialIndex>();
            _items = new List<ReferentialRow>();
        }

        public ReferentialIndex this[string name]
        {
            get
            {
                if (_dic.TryGetValue(name, out ReferentialIndex index))
                    return index;

                return None;

            }
        }

        public string Name { get; internal set; }

        internal void Add(ReferentialRow row)
        {
            _items.Add(row);
        }

        internal void Index(AccessorList properties)
        {

            foreach (AccessorItem property in properties)
                if (property.Type.IsEnum || property.Type == typeof(string) || property.Type.IsPrimitive)
                {

                    var index = new ReferentialIndex() { Name = property.Name };
                    _dic.Add(property.Name, index);
                    foreach (var item in _items)
                    {
                        var value = property.GetValue(item.Instance);
                        index.Add(value, item);
                    }
                }

        }

        public static ReferentialIndex None { get; private set; }

        private readonly Dictionary<string, ReferentialIndex> _dic;
        private readonly List<ReferentialRow> _items;

    }

}