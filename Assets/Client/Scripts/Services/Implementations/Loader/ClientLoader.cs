using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Client.Scripts.Services.Interfaces;

namespace Assets.Client.Scripts.Services.Implementations.Loader
{
    public class ClientLoader: XmlLoaderBase<Person>
    {
        protected override string InitializeXmlPath()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Person> Load()
        {
            throw new NotImplementedException();
        }
    }
}
