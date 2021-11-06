using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Client.Scripts.Services.Interfaces;

namespace Assets.Client.Scripts.Services.Implementations.Loader
{
    public abstract class XmlLoaderBase<TValue> : ILoader<TValue>
    {
        protected abstract string InitializeXmlPath();

        public abstract IEnumerable<TValue> Load();
    }
}
