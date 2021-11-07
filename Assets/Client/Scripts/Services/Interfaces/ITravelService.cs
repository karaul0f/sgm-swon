using Assets.Client.Scripts.Data;

namespace Assets.Client.Scripts.Services.Interfaces
{
    public interface ITravelService
    {
        TravelAftermath GetTravelResults(Tour tourConfiguration, Person victim);
    }
}
