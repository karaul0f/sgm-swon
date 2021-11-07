using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemControllerHandler : MonoBehaviour
{
    protected GameObject m_tourManager;
    protected TourManager m_tourManagerScript;
    protected GameObject m_gameManager;
    protected MessageManager m_messageManager;

    [SerializeField] protected Button m_buyButton;
    [SerializeField] protected Button m_aboutButton;
    protected ListItemController m_infoAboutItem;
    protected ListController m_listController;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        m_infoAboutItem = gameObject.GetComponent<ListItemController>();
        m_listController = gameObject.GetComponentInParent<ListController>();
        m_gameManager = GameObject.FindWithTag("GameManager");
        m_tourManager = GameObject.FindWithTag("TourManager");
        m_buyButton.onClick.AddListener(OnBuyClickHandler);
        m_aboutButton.onClick.AddListener(OnAboutClickHandler);
        m_tourManagerScript = m_tourManager.GetComponent<TourManager>();
        m_messageManager = m_gameManager.GetComponent<MessageManager>();
    }

    protected virtual void OnBuyClickHandler()
    {
        
    }

    protected virtual void OnAboutClickHandler()
    {
        m_messageManager.AddMessage(EMessageType.AboutMessage, m_infoAboutItem.Description);
    }
}
