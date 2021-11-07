using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TourCostHandler : MonoBehaviour
{
    private GameObject m_tourManager;
    private TourManager m_tourManagerScript;
    private Text m_costText;
    // Start is called before the first frame update
    void Start()
    {
        m_costText = gameObject.GetComponent<Text>();
        m_tourManager = GameObject.FindWithTag("TourManager");
        m_tourManagerScript = m_tourManager.GetComponent<TourManager>();
        m_tourManagerScript.TourConfigurator.OnCostChanged.AddListener(OnTourCostChanged);
    }

    void OnTourCostChanged(int newTourCostValue)
    {
        m_costText.text = "Стоимость тура: $" + newTourCostValue.ToString();

    }

    void Destroy()
    {
        m_tourManagerScript.TourConfigurator.OnCostChanged.RemoveListener(OnTourCostChanged);
    }
}
