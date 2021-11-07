using System.Collections.Generic;
using Assets.Client.Scripts.Data;
using Assets.Client.Scripts.Data.Features;
using Assets.Client.Scripts.Services.Enums;
using Assets.Client.Scripts.Services.Interfaces;

namespace Assets.Client.Scripts.Services.Implementations.Travel
{
    public class PrimitiveTravelService: ITravelService
    {
        private readonly IDictionary<EClientLifeStatus, string> _messageMap =
            new Dictionary<EClientLifeStatus, string>()
            {
                {EClientLifeStatus.Dead, "Клиент куда-то пропал... Мы не уверены, жив ли он"},
                {EClientLifeStatus.Healthy, "Добрый день! Спешу поделиться впечатлениями от поездки. Все было замечательно, море, солнце, погода) Отели очень понравились! Сервис хороший, парковка бесплатная и охраняемая). В очень живописном месте). Для уединения и релакса-туда).  Думаю, эта информация будет полезна для последующих туристов) Wi-fi в стандартной категории номеров бесплатный. Успели посмотреть достопримечательности). Многое понравилось). Впечатлений масса, как и фотографий красивых."},
                {EClientLifeStatus.Injured, "Добрый день! Все было просто ужасно, отель был очень отвратителен, номера грязные, санузлов нет, на экскурсии чуть не погиб!!!!!УЖАСНАЯ КОМПАНИЯ! НЕ РЕКОМЕНДУЮ!"}
            };

        public TravelAftermath GetTravelResults(Tour tourConfiguration, Person victim)
        {
            var result =  new TravelAftermath()
            {
                Client = victim,
                TourConfiguration = tourConfiguration,
                Events = GenerateEvents(tourConfiguration),
                ClientLifeStatus = ResolveClientLifeStatus(tourConfiguration, victim),
                Reward = ComputeReward(tourConfiguration, EClientLifeStatus.Healthy)
            };

            result.Message = _messageMap[result.ClientLifeStatus];

            return result;
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

        private EClientLifeStatus ResolveClientLifeStatus(Tour tourConfiguration, Person victim)
        {
            var totalRisk = tourConfiguration.Hotel.Risk + tourConfiguration.Excursion.Risk +
                            tourConfiguration.Transfer.Risk;

            if (totalRisk == 0)
            {
                return EClientLifeStatus.Healthy;
            }

            return totalRisk >= victim.MaxRisc ? EClientLifeStatus.Dead : EClientLifeStatus.Injured;
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
