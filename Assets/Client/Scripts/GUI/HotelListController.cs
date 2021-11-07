using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelListController : ListController
{
    public override void UpdateItems()
    {
        ClearAll();

        if (m_tourManagerScript.TourConfigurator.AvailableHotels == null)
            return;

        foreach (var country in m_tourManagerScript.TourConfigurator.AvailableHotels)
        {
            CreateElement(country.Name);
        }
    }
}
