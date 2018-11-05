using Bb.Core.Documents;
using System;
using System.Text;

namespace Bb.Workflow.Configurations.Documents
{

    public abstract class MemoryConfigurationDocument : IConfigurationDocument
    {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="file"></param>
        public MemoryConfigurationDocument(
            string name,
            IConfigurationVersion parent,
            TypeConfiguration type)
        {
            _name = name;
            Parent = parent;
            _type = type;
        }


        public string Name => _name;

        public DateTimeOffset CreationDate
        {
            get
            {
                if (_creationDate == DateTimeOffset.MinValue)
                    _loader(this);

                return _creationDate;
            }
            set => _creationDate = value;
        }

        public DateTimeOffset LastUpdate
        {
            get
            {
                if (_lastUpdate == DateTimeOffset.MinValue)
                    _loader(this);
                return _lastUpdate;
            }

            set => _lastUpdate = value;
        }

        protected abstract void _loader(MemoryConfigurationDocument memoryConfigurationDocument);

        public IConfigurationVersion Parent { get; }

        /// <summary>
        /// Gets the content of the configuration.
        /// </summary>
        /// <returns></returns>
        public StringBuilder Content
        {
            get
            {
                if (_content == null)
                    _loader(this);
                return _content;
            }
            set => _content = value;
        }

        public TypeConfiguration TypeConfiguration => _type;

        public virtual bool Rename(string newName)
        {
            _name = newName;
            return false;
        }

        public virtual bool Delete()
        {
            return true;
        }

        private static string GetValue(int time)
        {
            return time.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        public abstract void Save();

        private DateTimeOffset _creationDate;
        private DateTimeOffset _lastUpdate;
        private StringBuilder _content;
        private string _name;
        private readonly TypeConfiguration _type;

    }

}
