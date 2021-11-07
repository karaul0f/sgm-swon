using System.Collections.Generic;
using Assets.Client.Scripts.Data;
using Assets.Client.Scripts.Services.Enums;
using Assets.Client.Scripts.Services.Interfaces;

namespace Assets.Client.Scripts.Services.Implementations.Travel
{
    public class PrimitiveTravelService: ITravelService
    {
        public TravelAftermath GetTravelResults(Tour tourConfiguration, Person victim)
        {
            return new TravelAftermath()
            {
                Client = victim,
                TourConfiguration = tourConfiguration,
                Events = new List<TravelEvent>(),
                ClientLifeStatus = EClientLifeStatus.Healthy,
                Message = "Сдохни или умри"
            };
        }


    }
}
