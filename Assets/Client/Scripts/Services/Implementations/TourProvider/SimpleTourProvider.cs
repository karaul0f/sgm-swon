using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Client.Scripts.Services.Interfaces;

namespace Assets.Client.Scripts.Services.Implementations.TourProvider
{
    public class SimpleTourProvider: ITourProvider
    {
        private ILoader<Country> _countryLoader;

        public SimpleTourProvider(ILoader<Country> countryLoader)
        {
            _countryLoader = countryLoader;
        }

        public IEnumerable<Country> GetAvailableCountries()
        {
            var countries = _countryLoader.Load();
            return countries;
        }
    }
}
