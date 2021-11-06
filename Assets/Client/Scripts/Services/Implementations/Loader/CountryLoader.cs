using System;
using System.Collections.Generic;
using Assets.Client.Scripts.Services.Interfaces;

namespace Assets.Client.Scripts.Services.Implementations.Loader
{
    public class CountryLoader: XmlLoaderBase<Country>
    {
        protected override string InitializeXmlPath()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Country> Load()
        {
            throw new NotImplementedException();
        }
    }
}
