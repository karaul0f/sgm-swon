using System.Xml;
using Assets.Client.Scripts.Data.Features;

namespace Assets.Client.Scripts.Services.Implementations.Loader.Extensions
{
    public static class XmlExtractorExtension
    {
        public static Person ExtractPerson(this XmlNode node)
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

        public static  Transfer ExtractTransfer(this XmlNode node)
        {
            return new Transfer()
            {
                Name = node.Attributes.GetNamedItem(nameof(Excursion.Name)).Value,
                Description = node.Attributes.GetNamedItem(nameof(Excursion.Description)).Value,
                Price = int.Parse(node.Attributes.GetNamedItem(nameof(Excursion.Price)).Value),
                Image = node.Attributes.GetNamedItem(nameof(Excursion.Image)).Value,
                Risk = int.Parse(node.Attributes.GetNamedItem(nameof(Excursion.Risk)).Value)
            };
        }

        public static Hotel ExtractHotel(this XmlNode node)
        {
            return new Hotel
            {
                Name = node.Attributes.GetNamedItem(nameof(Excursion.Name)).Value,
                Description = node.Attributes.GetNamedItem(nameof(Excursion.Description)).Value,
                Price = int.Parse(node.Attributes.GetNamedItem(nameof(Excursion.Price)).Value),
                Image = node.Attributes.GetNamedItem(nameof(Excursion.Image)).Value,
                Risk = int.Parse(node.Attributes.GetNamedItem(nameof(Excursion.Risk)).Value)
            };
        }

        public static Excursion ExtractExcursion(this XmlNode node)
        {
            return new Excursion
            {
                Name = node.Attributes.GetNamedItem(nameof(Excursion.Name)).Value,
                Description = node.Attributes.GetNamedItem(nameof(Excursion.Description)).Value,
                Price = int.Parse(node.Attributes.GetNamedItem(nameof(Excursion.Price)).Value),
                Image = node.Attributes.GetNamedItem(nameof(Excursion.Image)).Value,
                Risk = int.Parse(node.Attributes.GetNamedItem(nameof(Excursion.Risk)).Value)
            };
        }
    }
}
