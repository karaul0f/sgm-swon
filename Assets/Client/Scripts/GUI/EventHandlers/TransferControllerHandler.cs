public class TransferControllerHandler : ItemControllerHandler
{
    protected override void OnBuyClickHandler()
    {
        m_tourManagerScript.TourConfigurator.SelectTransfer(m_infoAboutItem.Name.text);
    }
}
