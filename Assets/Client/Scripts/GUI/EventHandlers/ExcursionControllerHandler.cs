public class ExcursionControllerHandler : ItemControllerHandler
{
    protected override void OnBuyClickHandler()
    {
        m_tourManagerScript.TourConfigurator.SelectExcursion(m_infoAboutItem.Name.text);
    }
}
