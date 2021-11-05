using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppHandler : MonoBehaviour
{
    private TabManager m_tabManager;

    [SerializeField] private TabManager.Tab m_targetApplication;

    public GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        m_tabManager = GameManager.GetComponent(typeof(TabManager)) as TabManager;
        m_tabManager.OnTabChanged.AddListener(OnTabChangedHandler);
        OnTabChangedHandler(m_tabManager.CurrentTab);
    }

    void OnTabChangedHandler(TabManager.Tab newTabValue)
    {
        gameObject.SetActive(newTabValue == m_targetApplication);
        for (int i = 1; i < gameObject.transform.childCount - 2; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
