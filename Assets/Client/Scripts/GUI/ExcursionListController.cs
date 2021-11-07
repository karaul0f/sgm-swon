using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� ��� ��������� ����������� ������ ���������
/// </summary>
public class ExcursionListController : ListController
{
    public override void UpdateItems()
    {
        ClearAll();

        if (m_tourManagerScript.TourConfigurator.AvailableExcursions == null)
            return;

        foreach (var excursion in m_tourManagerScript.TourConfigurator.AvailableExcursions)
        {
            CreateElement(excursion.Name);
        }
    }
}
