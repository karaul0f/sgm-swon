using System.Collections.Generic;
using System.Xml;
using Assets.Client.Scripts.Services.Interfaces;

namespace Assets.Client.Scripts.Services.Implementations.Loader
{
    public abstract class XmlLoaderBase<TValue> : ILoader<TValue>
    {
        private string _path;

        private IEnumerable<TValue> _cachedData;

        protected XmlLoaderBase()
        {
            SetUpPath();
        }

        protected abstract string InitializeXmlPath();

        public IEnumerable<TValue> Load()
        {
            if (_cachedData == null)
                UpdateCache();
            
            return _cachedData;
        }

        protected abstract IEnumerable<TValue> ExtractData(XmlElement element);

        private void UpdateCache()
        {
            var resources = new XmlDocument();
            resources.Load(_path);

            var xRoot = resources.DocumentElement;

            _cachedData = ExtractData(xRoot);
        }

        private void SetUpPath()
        {
            _path = InitializeXmlPath();
        }
    }
}
