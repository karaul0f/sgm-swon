using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryListController : ListController
{
    // Start is called before the first frame update
    protected sealed override void Start()
    {
        base.Start();
        foreach (var country in m_tourManagerScript.TourConfigurator.AvailableCounties)
        {
            CreateElement(country.Name);
        }
    }

    public void UpdateItems()
    {
        ClearAll();
        foreach (var country in m_tourManagerScript.TourConfigurator.AvailableCounties)
        {
           CreateElement(country.Name);
        }
    }
}
