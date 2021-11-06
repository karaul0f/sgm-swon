using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryListController : ListController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        foreach (var county in m_tourManagerScript.TourConfigurator.AvailableCounties)
        {
            CreateElement(county.Name);
        }
    }

    public void UpdateItems()
    {
        ClearAll();
        foreach (var transfer in m_tourManagerScript.TourConfigurator.AvailableCounties)
        {
           CreateElement(transfer.Name);
        }
    }
}
