using System;
using System.Collections.Generic;

namespace Bb.Referentiels
{



    /// <summary>
    /// var r1 = referentials["ref_name"]["propery_name"]["value"];
    /// </summary>
    public class Referentials
    {

        public static Referential None { get; private set; }

        static Referentials()
        {
            Referentials.None = new Referential() { Name = "None" };
        }

        public Referentials()
        {
            _dic = new Dictionary<string, Referential>();
        }

        public Referential this[string name]
        {
            get
            {
                if (_dic.TryGetValue(name, out Referential referential))
                    return referential;

                return None;

            }
        }

        public void Load(IEnumerable<ReferentialConfig> configs)
        {
            foreach (var item in configs)
                Load(item);
        }

        public void Load(ReferentialConfig config)
        {

            if (config.Csv != null)
                Register(ReferentialLoader.Load(config.Csv));

            if (config.Json != null)
                Register(ReferentialLoader.Load(config.Json));

        }


        private void Register(Referential referential)
        {
            _dic.Add(referential.Name, referential);
        }

        private readonly Dictionary<string, Referential> _dic;

    }

}