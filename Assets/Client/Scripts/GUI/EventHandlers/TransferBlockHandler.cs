using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferBlockHandler : MonoBehaviour
{
    private GameObject m_tourManager;
    private TransferListController m_transferListController;

    // Start is called before the first frame update
    void Start()
    {
        m_tourManager = GameObject.FindGameObjectWithTag("TourManager");
        m_transferListController = gameObject.GetComponent<TransferListController>();
        TourManager tourManagerScript = m_tourManager.GetComponent(typeof(TourManager)) as TourManager;
        tourManagerScript.TourConfigurator.OnTourStatusChanged.AddListener(OnTourStatusChangedHandler);
    }

    void OnTourStatusChangedHandler(ETourStatus newTourStatusValue)
    {
        m_transferListController.UpdateItems();
    }
}
