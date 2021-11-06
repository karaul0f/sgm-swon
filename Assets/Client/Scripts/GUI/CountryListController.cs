using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryListController : ListController
{
    // Start is called before the first frame update
    void Start()
    {
        m_countVisualElements = 0;
        m_tourManagerScript = GameObject.FindGameObjectWithTag("TourManager").GetComponent<TourManager>();

        foreach (var county in m_tourManagerScript.TourConfigurator.AvailableCounties)
        {
            CreateElement(county.Name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ClearAll()
    {
        foreach (var element in m_elements)
        {
            Destroy(element);
        }
        m_elements.Clear();
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
