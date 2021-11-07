using System.Collections.Generic;
using System.Linq;
using Assets.Client.Scripts.Data;
using Assets.Client.Scripts.Services.Interfaces;

namespace Assets.Client.Scripts.Services.Implementations.TourProvider
{
    public class SimpleTourProvider: ITourProvider
    {
        private readonly ILoader<Country> _countryLoader;
        private readonly IGenerator<Person> _clientGenerator;

        public SimpleTourProvider(ILoader<Country> countryLoader, IGenerator<Person> clientGenerator)
        {
            _countryLoader = countryLoader;
            _clientGenerator = clientGenerator;
        }

        public IEnumerable<Country> GetAvailableCountries()
        {
            var countries = _countryLoader.Load();
            var filteredCountries = FilterCountries(countries);
            return filteredCountries;
        }

        private IEnumerable<Country> FilterCountries(IEnumerable<Country> source)
        {
            return source?
                .Where(country => 
                    _clientGenerator.Current.PreferredCountries
                        .Select(preferredCountry => preferredCountry.ToLower())
                        .Contains(country.Name.ToLower()));
        }
    }
}
