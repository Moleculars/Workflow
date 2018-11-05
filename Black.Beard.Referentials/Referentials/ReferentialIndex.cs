using System.Collections.Generic;
using System.Diagnostics;

namespace Bb.Referentiels
{
    [DebuggerDisplay("{Name}")]
    public class ReferentialIndex
    {

        static ReferentialIndex()
        {
            ReferentialIndex.None = new List<object>();
        }

        public ReferentialIndex()
        {
            _items = new Dictionary<object, List<object>>();
        }

        public string Name { get; internal set; }

        public static List<object> None { get; }

        public List<object> this [string name]
        {
            get
            {

                if (_items.TryGetValue(name, out List<object> list))
                    return list;

                return None;

            }
        }

        internal void Add(object value, ReferentialRow item)
        {
            if (!_items.TryGetValue(value, out List<object> list))
                _items.Add(value, list = new List<object>());

            list.Add(item.Instance);

        }

        private Dictionary<object, List<object>> _items;

    }

}