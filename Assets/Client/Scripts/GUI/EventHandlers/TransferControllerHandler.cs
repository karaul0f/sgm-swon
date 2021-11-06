using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferControllerHandler : MonoBehaviour
{
    private GameObject m_tourManager;
    private TourManager m_tourManagerScript;
    [SerializeField] private Button m_buyButton;
    private ListItemController m_infoAboutItem;

    // Start is called before the first frame update
    void Start()
    {
        m_infoAboutItem = gameObject.GetComponent<ListItemController>();
        m_tourManager = GameObject.FindWithTag("TourManager");
        m_buyButton.onClick.AddListener(OnBuyClickHandler);
        m_tourManagerScript = m_tourManager.GetComponent<TourManager>();
    }

    void OnBuyClickHandler()
    {
        m_tourManagerScript.TourConfigurator.SelectTransfer(m_infoAboutItem.Name.text);
    }
}
