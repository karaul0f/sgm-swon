public class TransferListController : ListController
{
    // Start is called before the first frame update
    protected sealed override void Start() 
    { 
        base.Start();
    }

    public override void UpdateItems()
    {
        ClearAll();

        if (m_tourManagerScript.TourConfigurator.AvailableTransfers == null)
            return;

        CreateElements();
    }

    public void CreateElements()
    {
        foreach (var transfer in m_tourManagerScript.TourConfigurator.AvailableTransfers)
        {
            CreateElement(transfer.Name, transfer.Description, transfer.Price, transfer.Image, transfer == m_tourManagerScript.TourConfigurator.SelectedTransfer);
        }
    }
}
