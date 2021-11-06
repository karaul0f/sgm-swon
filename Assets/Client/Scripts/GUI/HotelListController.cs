using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelListController : ListController
{
    // Start is called before the first frame update
    void Start()
    {
        m_tourManager = GameObject.FindWithTag("TourManager");
        m_tourManagerScript = m_tourManager.GetComponent<TourManager>();
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
        foreach (var transfer in m_tourManagerScript.TourConfigurator.AvailableHotels)
        {
            CreateElement(transfer.Name);
        }
    }
}
