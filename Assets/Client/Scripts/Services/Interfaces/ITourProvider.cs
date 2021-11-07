using System.Collections.Generic;
using Assets.Client.Scripts.Data;

namespace Assets.Client.Scripts.Services.Interfaces
{
    public interface ITourProvider
    {
        IEnumerable<Country> GetAvailableCountries();
    }
}
