using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс для обработки визуального списка экскурсий
/// </summary>
public class ExcursionListController : ListController
{
    // Start is called before the first frame update
    void Start()
    {
        m_tourManager = GameObject.FindWithTag("TourManager");
        m_countVisualElements = 0;
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
        foreach (var transfer in m_tourManagerScript.TourConfigurator.AvailableExcursions)
        {
            CreateElement(transfer.Name);
        }
    }
}
