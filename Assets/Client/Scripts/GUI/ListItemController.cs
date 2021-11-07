using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItemController : MonoBehaviour
{
    private bool m_isSelected;
    void Awake()
    {
        m_isSelected = false;
    }

    public Image Icon;
    public Text Name, Description, Price;

    /// <summary>
    /// Выбран ли текущий элемент
    /// </summary>
    public bool IsSelected
    {
        get => m_isSelected;
    }
}
