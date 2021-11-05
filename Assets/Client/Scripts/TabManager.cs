using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TabManager : MonoBehaviour
{
    [SerializeField] private Tab m_currentTab;

    private UnityEvent<Tab> m_onTabChanged;

    public UnityEvent<Tab> OnTabChanged
    {
        get => m_onTabChanged;
    }

    /// <summary>
    /// ������� ������� �������� (�������, ��������� ����, ������ ��������)
    /// </summary>
    public Tab CurrentTab
    {
        get => m_currentTab;
        private set
        {
            m_currentTab = value;
            m_onTabChanged.Invoke(m_currentTab);
        }
    }

    public enum Tab
    {
        News,
        Tours,
        Reviews
    }

    /// <summary>
    ///  ����� ��� �������� ��������� OnClick �� ���
    /// </summary>
    /// <param name="tab"></param>
    public void SetTab(int tab)
    {
        CurrentTab = (Tab)tab;
    }

    void Awake()
    {
        if (m_onTabChanged == null)
            m_onTabChanged = new UnityEvent<Tab>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
