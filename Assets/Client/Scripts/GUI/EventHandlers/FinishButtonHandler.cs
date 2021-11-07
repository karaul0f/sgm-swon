using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject m_targetBlock;
    private GameObject m_tourManager;
    private GameObject m_gameManager;

    private Capital m_capital;
    private TourManager m_tourManagerScript;
    private Button m_selfButton;
    private Text m_textOnButton;

    // Start is called before the first frame update
    void Start()
    {
        m_gameManager = GameObject.FindWithTag("GameManager");
        m_tourManager = GameObject.FindWithTag("TourManager");
        m_capital = m_gameManager.GetComponent<Capital>();
        m_selfButton = gameObject.GetComponent<Button>();
        m_textOnButton = m_selfButton.GetComponentInChildren<Text>();
        m_tourManagerScript = m_tourManager.GetComponent<TourManager>();
        m_tourManagerScript.TourConfigurator.OnTourStatusChanged.AddListener(OnTourStatusChangedHandler);
        m_tourManagerScript.OnBlockChanged.AddListener(OnBlockChangedHandler);
        OnTourStatusChangedHandler(m_tourManagerScript.TourConfigurator.TourCompleteStatus);
        OnBlockChangedHandler(m_tourManagerScript.CurrentBlock);
        m_selfButton.onClick.AddListener(OnClickHandler);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTourStatusChangedHandler(ETourStatus newTourStatus)
    {
        UpdateButton();
    }

    void OnBlockChangedHandler(GameObject newBlockObject)
    {
        UpdateButton();
    }

    void UpdateButton()
    {
        m_selfButton.interactable = m_tourManagerScript.TourConfigurator.TourCompleteStatus == ETourStatus.Final 
                                    && m_tourManagerScript.TourConfigurator.CurrentTourCost < m_capital.Money;

        gameObject.SetActive(m_tourManagerScript.CurrentBlock == m_targetBlock);
    }

    void OnClickHandler()
    {
        m_tourManagerScript.BeginNewTour();
    }

    void Destroy()
    {
        m_selfButton.onClick.RemoveListener(OnClickHandler);
    }
}
