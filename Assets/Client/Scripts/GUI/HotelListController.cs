using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelListController : ListController
{
    // Start is called before the first frame update
    protected sealed override void Start() { base.Start(); }

    public void UpdateItems()
    {
        ClearAll();
        foreach (var hotel in m_tourManagerScript.TourConfigurator.AvailableHotels)
        {
            CreateElement(hotel.Name);
        }
    }
}
