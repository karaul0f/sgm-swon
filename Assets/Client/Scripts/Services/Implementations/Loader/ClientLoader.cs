using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Assets.Client.Scripts.Data;
using Assets.Client.Scripts.Services.Implementations.Loader.Extensions;

namespace Assets.Client.Scripts.Services.Implementations.Loader
{
    public class ClientLoader: XmlLoaderBase<Person>
    {
        private const string PersonsNodeName = "Persons";

        protected override string InitializeXmlPath()
        {
            return Path.Combine("Assets", "Client", "Resources", "Persons.xml");
        }

        protected override IEnumerable<Person> ExtractData(XmlElement element)
        {
            var firstNode = element.FirstChild;

            if (firstNode.Name != PersonsNodeName && firstNode.HasChildNodes) return null;

            return (from XmlNode personNode in firstNode.ChildNodes
                where personNode.Attributes != null
                select personNode.ExtractPerson()).ToList();
        }
    }
}
