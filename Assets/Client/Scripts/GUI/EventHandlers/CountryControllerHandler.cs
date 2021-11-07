/// <summary>
/// Класс обработки выбора страны
/// </summary>
public class CountryControllerHandler : ItemControllerHandler
{
    protected override void OnBuyClickHandler()
    {
        m_tourManagerScript.TourConfigurator.SelectCounty(m_infoAboutItem.Name.text);
    }
}
