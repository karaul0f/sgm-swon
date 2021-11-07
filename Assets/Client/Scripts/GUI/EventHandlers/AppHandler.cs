using UnityEngine;

public class AppHandler : MonoBehaviour
{
    private TabManager m_tabManager;

    [SerializeField] private ETab m_targetApplication;

    public GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        m_tabManager = GameManager.GetComponent(typeof(TabManager)) as TabManager;
        m_tabManager.OnTabChanged.AddListener(OnTabChangedHandler);
        OnTabChangedHandler(m_tabManager.CurrentTab);
    }

    void OnTabChangedHandler(ETab newTabValue)
    {
        gameObject.SetActive(newTabValue == m_targetApplication);
    }
}
