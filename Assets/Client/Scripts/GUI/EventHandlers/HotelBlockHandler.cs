using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelBlockHandler : MonoBehaviour
{
    private GameObject m_tourManager;
    private HotelListController m_hotelListController;

    // Start is called before the first frame update
    void Start()
    {
        m_tourManager = GameObject.FindGameObjectWithTag("TourManager");
        m_hotelListController = gameObject.GetComponent<HotelListController>();
        TourManager tourManagerScript = m_tourManager.GetComponent(typeof(TourManager)) as TourManager;
        tourManagerScript.TourConfigurator.OnTourStatusChanged.AddListener(OnTourStatusChangedHandler);
    }

    void OnTourStatusChangedHandler(ETourStatus newTourStatusValue)
    {
        m_hotelListController.UpdateItems();
    }
}
