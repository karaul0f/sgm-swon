using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TabManager : MonoBehaviour
{
    [SerializeField] private ETab m_currentTab;

    private UnityEvent<ETab> m_onTabChanged;

    public UnityEvent<ETab> OnTabChanged
    {
        get => m_onTabChanged;
    }

    /// <summary>
    /// Текущая вкладка ноутбука (новости, настройка тура, оценки клиентов)
    /// </summary>
    public ETab CurrentTab
    {
        get => m_currentTab;
        private set
        {
            m_currentTab = value;
            m_onTabChanged.Invoke(m_currentTab);
        }
    }

    /// <summary>
    ///  Метод для нативной поддержки OnClick из ГУИ
    /// </summary>
    /// <param name="tab"></param>
    public void SetTab(int tab)
    {
        CurrentTab = (ETab)tab;
    }

    void Awake()
    {
        if (m_onTabChanged == null)
            m_onTabChanged = new UnityEvent<ETab>();
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
