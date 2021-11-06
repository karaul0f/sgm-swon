using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryBlockHandler : MonoBehaviour
{
    private GameObject m_tourManager;
    private CountryListController m_countryListController;

    // Start is called before the first frame update
    void Start()
    {
        m_tourManager = GameObject.FindGameObjectWithTag("TourManager");
        m_countryListController = gameObject.GetComponent<CountryListController>();
        TourManager tourManagerScript = m_tourManager.GetComponent(typeof(TourManager)) as TourManager;
        tourManagerScript.TourConfigurator.OnTourStatusChanged.AddListener(OnTourStatusChangedHandler);
    }

    void OnTourStatusChangedHandler(ETourStatus newTourStatusValue)
    {
        m_countryListController.UpdateItems();
    }
}
