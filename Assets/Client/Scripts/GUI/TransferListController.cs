using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferListController : ListController
{
    // Start is called before the first frame update
    protected sealed override void Start() 
    { 
        base.Start();
        foreach (var transfer in m_tourManagerScript.TourConfigurator.AvailableTransfers)
        {
            CreateElement(transfer.Name, transfer.Description, transfer.Price, transfer.Image);
        }
    }

    public override void UpdateItems()
    {
        ClearAll();

        if (m_tourManagerScript.TourConfigurator.AvailableTransfers == null)
            return;

        foreach (var transfer in m_tourManagerScript.TourConfigurator.AvailableTransfers)
        {
            CreateElement(transfer.Name, transfer.Description, transfer.Price, transfer.Image);
        }
    }
}
