using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс для обработки визуального списка экскурсий
/// </summary>
public class ExcursionListController : ListController
{
    // Start is called before the first frame update
    protected sealed override void Start() { base.Start();}

    public void UpdateItems()
    {
        ClearAll();
        foreach (var excursion in m_tourManagerScript.TourConfigurator.AvailableExcursions)
        {
            CreateElement(excursion.Name, excursion.Description, excursion.Price, excursion.Image);
        }
    }
}
