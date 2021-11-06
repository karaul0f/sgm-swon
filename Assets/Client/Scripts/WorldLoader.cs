using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using UnityEngine;

public class WorldLoader : MonoBehaviour
{
    private List<Person> m_persons;
    private Dictionary<string, Country> m_countries;

    public List<Person> Persons { get { return m_persons; } }
    public Dictionary<string, Country> Countries { get { return m_countries; } }

    // Start is called before the first frame update
    public void Awake()
    {
        m_persons =     LoadPersonsFromFile(@"Assets\Client\Resources\Persons.xml");
        m_countries =   LoadCountriesFromFile(@"Assets\Client\Resources\Countries.xml");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<Person> LoadPersonsFromFile(string filePath)
    {
        List<Person> persons = new List<Person>();

        XmlDocument resources = new XmlDocument();
        resources.Load(filePath);

        XmlElement xRoot = resources.DocumentElement;
        foreach (XmlNode xNode in xRoot)
        {
            if (xNode.Name == "Persons")
            {
                foreach (XmlNode personNode in xNode.ChildNodes)
                {
                    Person person = new Person();

                    person.Name = personNode.Attributes.GetNamedItem("Name").Value;
                    person.Phrase = personNode.Attributes.GetNamedItem("Phrase").Value;
                    person.PreferredCountries = personNode.Attributes.GetNamedItem("PreferredCountries").Value;
                    person.Budget = personNode.Attributes.GetNamedItem("Budget").Value;
                    person.MaxRisc = personNode.Attributes.GetNamedItem("MaxRisc").Value;
                    person.Image = personNode.Attributes.GetNamedItem("Image").Value;

                    persons.Add(person);
                }
            }
        }

        return persons;
    }

    private Dictionary<string, Country> LoadCountriesFromFile(string filePath)
    {
        Dictionary<string, Country> countries = new Dictionary<string, Country>();

        XmlDocument resources = new XmlDocument();
        resources.Load(filePath);

        XmlElement xRoot = resources.DocumentElement;
        foreach (XmlNode xNode in xRoot)
        {
            if (xNode.Name == "Countries")
            {
                foreach (XmlNode countryNode in xNode.ChildNodes)
                {
                    List<Transfer> transfers = new List<Transfer>();
                    List<Hotel> hotels = new List<Hotel>();
                    List<Excursion> excursions = new List<Excursion>();

                    Country country = new Country();
                    country.Name = countryNode.Attributes.GetNamedItem("Name").Value;

                    foreach (XmlNode subCountryNode in countryNode.ChildNodes)
                    {
                        if (subCountryNode.Name == "Transfers")
                        {
                            foreach (XmlNode transferNode in subCountryNode.ChildNodes)
                            {
                                Transfer transfer = new Transfer();

                                transfer.Name = transferNode.Attributes.GetNamedItem("Name").Value;
                                transfer.Description = transferNode.Attributes.GetNamedItem("Description").Value;
                                transfer.Price = transferNode.Attributes.GetNamedItem("Price").Value;
                                transfer.Image = transferNode.Attributes.GetNamedItem("Image").Value;
                                transfer.Risc = transferNode.Attributes.GetNamedItem("Risc").Value;

                                transfers.Add(transfer);
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

                                hotels.Add(hotel);
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

                                excursions.Add(excursion);
                            }
                        }
                    }

                    country.Transfers = transfers;
                    country.Hotels = hotels;
                    country.Excursions = excursions;

                    countries.Add(country.Name, country);
                }
            }
        }

        return countries;
    }
}
