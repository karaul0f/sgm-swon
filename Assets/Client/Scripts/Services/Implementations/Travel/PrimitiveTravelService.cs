using System.Collections.Generic;
using Assets.Client.Scripts.Data;
using Assets.Client.Scripts.Data.Features;
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
                Events = GenerateEvents(tourConfiguration),
                ClientLifeStatus = EClientLifeStatus.Healthy,
                Message = "Сдохни или умри",
                Reward = ComputeReward(tourConfiguration, EClientLifeStatus.Healthy)
            };
        }

        private IEnumerable<TravelEvent> GenerateEvents(Tour configuration)
        {
            var result = new List<TravelEvent>
            {
                ExtractEvent(configuration.Transfer),
                ExtractEvent(configuration.Hotel),
                ExtractEvent(configuration.Excursion)
            };

            return result;
        }

        private static TravelEvent ExtractEvent(FeatureBase hotelData)
        {
            return new TravelEvent()
            {
                Name = hotelData.RiskName,
                Damage = hotelData.Risk
            };
        }

        private static int ComputeReward(Tour config, EClientLifeStatus status)
        {
            return status == EClientLifeStatus.Dead ? 0 : config.Excursion.Price + config.Hotel.Price + config.Transfer.Price;
        }
    }
}
