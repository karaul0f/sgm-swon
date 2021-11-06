using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс для обработки визуального списка экскурсий
/// </summary>
public class ExcursionListController : ListController
{
    // Start is called before the first frame update
    protected override void Start() { base.Start(); }

    public void UpdateItems()
    {
        ClearAll();
        foreach (var transfer in m_tourManagerScript.TourConfigurator.AvailableExcursions)
        {
            CreateElement(transfer.Name);
        }
    }
}
