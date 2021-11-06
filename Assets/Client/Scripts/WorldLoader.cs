using System.Collections.Generic;
using System.Linq;
using Assets.Client.Scripts.Services.Interfaces;
using UnityEngine;
using Zenject;

public class WorldLoader : MonoBehaviour
{
    private ILoader<Person> _clientLoader;
    private ILoader<Country> _countryLoader;

    public IEnumerable<Person> Persons { get; private set; }
    public IDictionary<string, Country> Countries { get; private set; }

    [Inject]
    public void Construct(ILoader<Person> clientLoader, ILoader<Country> countryLoader)
    {
        _clientLoader = clientLoader;
        _countryLoader = countryLoader;
    }

    // Start is called before the first frame update
    public void Awake()
    {
        InitializeClients();
        InitializeCountries();
    }

    private void InitializeClients()
    {
        Persons = _clientLoader.Load();
    }

    private void InitializeCountries()
    {
        var countries = _countryLoader.Load();

        Countries = countries.Aggregate(new Dictionary<string, Country>(), (countriesMap, country) =>
        {
            countriesMap.Add(country.Name, country);
            return countriesMap;
        });
    }
}
