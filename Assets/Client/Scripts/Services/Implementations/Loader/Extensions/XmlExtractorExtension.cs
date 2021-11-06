using System.Xml;

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
                Name = node.Attributes.GetNamedItem(nameof(Transfer.Name)).Value,
                Description = node.Attributes.GetNamedItem(nameof(Transfer.Description)).Value,
                Price = node.Attributes.GetNamedItem(nameof(Transfer.Price)).Value,
                Image = node.Attributes.GetNamedItem(nameof(Transfer.Image)).Value,
                Risc = node.Attributes.GetNamedItem(nameof(Transfer.Risc)).Value
            };
        }

        public static Hotel ExtractHotel(this XmlNode node)
        {
            return new Hotel
            {
                Name = node.Attributes.GetNamedItem(nameof(Hotel.Name)).Value,
                Description = node.Attributes.GetNamedItem(nameof(Hotel.Description)).Value,
                Price = node.Attributes.GetNamedItem(nameof(Hotel.Price)).Value,
                Image = node.Attributes.GetNamedItem(nameof(Hotel.Image)).Value,
                Risc = node.Attributes.GetNamedItem(nameof(Hotel.Risc)).Value
            };
        }

        public static Excursion ExtractExcursion(this XmlNode node)
        {
            return new Excursion
            {
                Name = node.Attributes.GetNamedItem(nameof(Excursion.Name)).Value,
                Description = node.Attributes.GetNamedItem(nameof(Excursion.Description)).Value,
                Price = node.Attributes.GetNamedItem(nameof(Excursion.Price)).Value,
                Image = node.Attributes.GetNamedItem(nameof(Excursion.Image)).Value,
                Risc = node.Attributes.GetNamedItem(nameof(Excursion.Risc)).Value
            };
        }
    }
}
