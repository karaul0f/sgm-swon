using System.Xml;

namespace Assets.Client.Scripts.Services.Implementations.Loader.Extensions
{
    public static class PersonXmlExtractorExtension
    {
        public static Person Extract(this XmlNode node)
        {
            return new Person() 
            {
                Name = node.Attributes.GetNamedItem(nameof(Person.Name)).Value,
                Phrase = node.Attributes.GetNamedItem(nameof(Person.Phrase)).Value,
                PreferredCountries = node.Attributes.GetNamedItem(nameof(Person.PreferredCountries)).Value,
                Budget = node.Attributes.GetNamedItem(nameof(Person.Budget)).Value,
                MaxRisc = node.Attributes.GetNamedItem(nameof(Person.MaxRisc)).Value,
                Image = node.Attributes.GetNamedItem(nameof(Person.Image)).Value
            };
        }
    }
}
