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

        foreach (var hotel in m_tourManagerScript.TourConfigurator.AvailableHotels)
        {
            CreateElement(hotel.Name, hotel.Description, hotel.Price, hotel.Image);
        }
    }
}
