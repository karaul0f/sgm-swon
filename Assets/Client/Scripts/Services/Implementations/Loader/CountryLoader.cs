using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Assets.Client.Scripts.Data;
using Assets.Client.Scripts.Services.Implementations.Loader.Extensions;

namespace Assets.Client.Scripts.Services.Implementations.Loader
{
    public class CountryLoader: XmlLoaderBase<Country>
    {
        private const string CountryNodeName = "Countries";
        private const string TransferNodeName = "Transfers";
        private const string HotelNodeName = "Hotels";
        private const string ExcursionNodeName = "Excursions";

        private static readonly IDictionary<string, Func<XmlNode, object>> NodeNameToExtractorMap =
            new Dictionary<string, Func<XmlNode, object>>
            {
                {TransferNodeName, node => node.ExtractTransfer()},
                {HotelNodeName, node => node.ExtractHotel()},
                {ExcursionNodeName, node => node.ExtractExcursion()}
    };


        protected override string InitializeXmlPath()
        {
            return Path.Combine("Assets", "Client", "Resources", "Countries.xml");
        }

        protected override IEnumerable<Country> ExtractData(XmlElement element)
        {
            var result = new List<Country>();

            var countryNodes = element.Cast<XmlNode>().Where(xNode => xNode.Name == CountryNodeName);

            foreach (var xNode in countryNodes)
            {
                result.AddRange(from XmlNode countryNode in xNode.ChildNodes select ExtractCountry(countryNode));
            }

            return result;
        }

        private Country ExtractCountry(XmlNode node)
        {
            var country = new Country
            {
                Name = node.Attributes.GetNamedItem(nameof(Country.Name)).Value
            };

            foreach (XmlNode subCountryNode in node.ChildNodes)
            {
                switch (subCountryNode.Name)
                {
                    case TransferNodeName:
                        _ = country.Transfers = ExtractListOfNodes(subCountryNode)
                            .Aggregate(new Dictionary<string, Transfer>(), GetTransfers);
                        break;
                    case HotelNodeName:
                        _ = country.Hotels = ExtractListOfNodes(subCountryNode)
                            .Aggregate(new Dictionary<string, Hotel>(), GetHotels);
                        break;
                    case ExcursionNodeName:
                        _ = country.Excursions = ExtractListOfNodes(subCountryNode)
                            .Aggregate(new Dictionary<string, Excursion>(), GetExcursions);
                        break;
                    default:
                        continue;
                }
            }

            return country;
        }

        private static Dictionary<string, Transfer> GetTransfers(Dictionary<string, Transfer> transfers, object data)
        {
            var transfer = data as Transfer;
            transfers.Add(transfer.Name, transfer);
            return transfers;
        }

        private static Dictionary<string, Hotel> GetHotels(Dictionary<string, Hotel> hotels, object data)
        {
            var hotel = data as Hotel;
            hotels.Add(hotel.Name, hotel);
            return hotels;
        }

        private static Dictionary<string, Excursion> GetExcursions(Dictionary<string, Excursion> excursions, object data)
        {
            var excursion = data as Excursion;
            excursions.Add(excursion.Name, excursion);
            return excursions;
        }

        private IEnumerable<object> ExtractListOfNodes(XmlNode node)
        {
            return !NodeNameToExtractorMap.ContainsKey(node.Name) ? null :
                (from XmlNode childNode
                    in node.ChildNodes
                 select NodeNameToExtractorMap[node.Name](childNode)).ToList();
        }
    }
}
