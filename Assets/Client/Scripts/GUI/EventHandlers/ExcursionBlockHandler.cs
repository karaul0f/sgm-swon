using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс для обработки событий блока экскурсий
/// </summary>
public class ExcursionBlockHandler : MonoBehaviour
{
    private GameObject m_tourManager;
    private ExcursionListController m_excursionListController;

    // Start is called before the first frame update
    void Start()
    {
        m_tourManager = GameObject.FindGameObjectWithTag("TourManager");
        m_excursionListController = gameObject.GetComponent<ExcursionListController>();
        TourManager tourManagerScript = m_tourManager.GetComponent(typeof(TourManager)) as TourManager;
        tourManagerScript.TourConfigurator.OnTourStatusChanged.AddListener(OnTourStatusChangedHandler);
    }

    void OnTourStatusChangedHandler(ETourStatus newTourStatusValue)
    {
        m_excursionListController.UpdateItems();
    }
}
