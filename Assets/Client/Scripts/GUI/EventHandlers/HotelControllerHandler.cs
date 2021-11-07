public class HotelControllerHandler : ItemControllerHandler
{
    protected override void OnBuyClickHandler()
    {
        m_tourManagerScript.TourConfigurator.SelectHotel(m_infoAboutItem.Name.text);
    }
}
