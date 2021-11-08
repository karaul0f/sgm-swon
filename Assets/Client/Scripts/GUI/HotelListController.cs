public class HotelListController : ListController
{
    public override void UpdateItems()
    {
        ClearAll();

        if (m_tourManagerScript.TourConfigurator.AvailableHotels == null)
            return;

        foreach (var hotel in m_tourManagerScript.TourConfigurator.AvailableHotels)
        {
            CreateElement(hotel.Name, hotel.Description, hotel.Price, hotel.Image, hotel == m_tourManagerScript.TourConfigurator.SelectedHotel);
        }
    }
}
