using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Assets.Client.Scripts.Services.Implementations.Loader
{
    public class CountryLoader: XmlLoaderBase<Country>
    {
        protected override string InitializeXmlPath()
        {
            return Path.Combine("Assets", "Client", "Resources", "Countries.xml");
        }

        protected override IEnumerable<Country> ExtractData(XmlElement element)
        {
            var result = new List<Country>();

            foreach (XmlNode xNode in element)
            {
                if (xNode.Name == "Countries")
                {
                    foreach (XmlNode countryNode in xNode.ChildNodes)
                    {
                        Dictionary<string, Transfer> transfers = new Dictionary<string, Transfer>();
                        Dictionary<string, Hotel> hotels = new Dictionary<string, Hotel>();
                        Dictionary<string, Excursion> excursions = new Dictionary<string, Excursion>();

                        Country country = new Country();
                        country.Name = countryNode.Attributes.GetNamedItem("Name").Value;

                        foreach (XmlNode subCountryNode in countryNode.ChildNodes)
                        {
                            if (subCountryNode.Name == "Transfers")
                            {
                                foreach (XmlNode transferNode in subCountryNode.ChildNodes)
                                {
                                    var transfer = ExtractTransferData(transferNode);


                                    transfers.Add(transfer.Name, transfer);
                                }
                            }
                            if (subCountryNode.Name == "Hotels")
                            {
                                foreach (XmlNode hotelNode in subCountryNode.ChildNodes)
                                {
                                    Hotel hotel = new Hotel();

                                    hotel.Name = hotelNode.Attributes.GetNamedItem("Name").Value;
                                    hotel.Description = hotelNode.Attributes.GetNamedItem("Description").Value;
                                    hotel.Price = hotelNode.Attributes.GetNamedItem("Price").Value;
                                    hotel.Image = hotelNode.Attributes.GetNamedItem("Image").Value;
                                    hotel.Risc = hotelNode.Attributes.GetNamedItem("Risc").Value;

                                    hotels.Add(hotel.Name, hotel);
                                }
                            }
                            if (subCountryNode.Name == "Excursions")
                            {
                                foreach (XmlNode excursionNode in subCountryNode.ChildNodes)
                                {
                                    Excursion excursion = new Excursion();

                                    excursion.Name = excursionNode.Attributes.GetNamedItem("Name").Value;
                                    excursion.Description = excursionNode.Attributes.GetNamedItem("Description").Value;
                                    excursion.Price = excursionNode.Attributes.GetNamedItem("Price").Value;
                                    excursion.Image = excursionNode.Attributes.GetNamedItem("Image").Value;
                                    excursion.Risc = excursionNode.Attributes.GetNamedItem("Risc").Value;

                                    excursions.Add(excursion.Name, excursion);
                                }
                            }
                        }

                        country.Transfers = transfers;
                        country.Hotels = hotels;
                        country.Excursions = excursions;

                        result.Add(country);
                    }
                }
            }

            return result;
        }

        private static Transfer ExtractTransferData(XmlNode transferNode)
        {
            return new Transfer()
            {
                Name = transferNode.Attributes.GetNamedItem(nameof(Transfer.Name)).Value,
                Description = transferNode.Attributes.GetNamedItem(nameof(Transfer.Description)).Value,
                Price = transferNode.Attributes.GetNamedItem(nameof(Transfer.Price)).Value,
                Image = transferNode.Attributes.GetNamedItem(nameof(Transfer.Image)).Value,
                Risc = transferNode.Attributes.GetNamedItem(nameof(Transfer.Risc)).Value
            };
        }
    }
}
