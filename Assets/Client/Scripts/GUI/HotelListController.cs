using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelListController : ListController
{
    // Start is called before the first frame update
    protected override void Start() { base.Start(); }

    public void UpdateItems()
    {
        ClearAll();
        foreach (var transfer in m_tourManagerScript.TourConfigurator.AvailableHotels)
        {
            CreateElement(transfer.Name);
        }
    }
}
