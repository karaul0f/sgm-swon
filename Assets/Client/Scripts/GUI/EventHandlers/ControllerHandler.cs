using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerHandler : MonoBehaviour
{
    protected GameObject m_tourManager;
    protected TourManager m_tourManagerScript;
    [SerializeField] protected Button m_buyButton;
    protected ListItemController m_infoAboutItem;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        m_infoAboutItem = gameObject.GetComponent<ListItemController>();
        m_tourManager = GameObject.FindWithTag("TourManager");
        m_buyButton.onClick.AddListener(OnBuyClickHandler);
        m_tourManagerScript = m_tourManager.GetComponent<TourManager>();
    }

    protected virtual void OnBuyClickHandler()
    {
        
    }
}
