using System.Collections.Generic;
using System.Xml;
using Assets.Client.Scripts.Services.Interfaces;

namespace Assets.Client.Scripts.Services.Implementations.Loader
{
    public abstract class XmlLoaderBase<TValue> : ILoader<TValue>
    {
        private string _path;

        protected XmlLoaderBase()
        {
            SetUpPath();
        }


        protected abstract string InitializeXmlPath();

        public IEnumerable<TValue> Load()
        {
            var resources = new XmlDocument();
            resources.Load(_path);

            var xRoot = resources.DocumentElement;

            var data = ExtractData(xRoot);

            return data;
        }

        protected abstract IEnumerable<TValue> ExtractData(XmlElement element);

        private void SetUpPath()
        {
            _path = InitializeXmlPath();
        }
    }
}
