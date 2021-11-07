using System.Collections.Generic;
using Assets.Client.Scripts.Services.Enums;

namespace Assets.Client.Scripts.Data
{
    public class TravelAftermath
    {
        public Tour TourConfiguration { get; set; }
        public Person Client { get; set; }
        public IEnumerable<TravelEvent> Events { get; set; }
        public EClientLifeStatus ClientLifeStatus { get; set; }
        public string Message { get; set; }
    }
}
