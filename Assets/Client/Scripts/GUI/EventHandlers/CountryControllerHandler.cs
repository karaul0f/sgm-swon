using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����� ��������� ������ ������
/// </summary>
public class CountryControllerHandler : ControllerHandler
{
    protected override void OnBuyClickHandler()
    {
        m_tourManagerScript.TourConfigurator.SelectCounty(m_infoAboutItem.Name.text);
    }
}
