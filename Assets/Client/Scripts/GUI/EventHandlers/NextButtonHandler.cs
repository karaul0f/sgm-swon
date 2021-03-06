using UnityEngine;
using UnityEngine.UI;

public class NextButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject m_notTargetBlock;
    [SerializeField] private GameObject m_tourManager;

    private TourManager m_tourManagerScript;
    private Button m_selfButton;
    private Text m_textOnButton;

    // Start is called before the first frame update
    void Start()
    {
        m_selfButton = gameObject.GetComponent<Button>();
        m_textOnButton = m_selfButton.GetComponentInChildren<Text>();
        m_tourManagerScript = m_tourManager.GetComponent<TourManager>();
        m_tourManagerScript.TourConfigurator.OnTourStatusChanged.AddListener(OnTourStatusChangedHandler);
        m_tourManagerScript.OnBlockChanged.AddListener(OnBlockChangedHandler);
        m_tourManagerScript.OnFinishTour.AddListener(OnFinishHandler);
        OnTourStatusChangedHandler(m_tourManagerScript.TourConfigurator.TourCompleteStatus);
        OnBlockChangedHandler(m_tourManagerScript.CurrentBlock);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTourStatusChangedHandler(ETourStatus newTourStatus)
    {
        UpdateButton(newTourStatus);
    }

    void OnBlockChangedHandler(GameObject newBlockObject)
    {
        UpdateButton(newBlockObject);
    }

    void UpdateButton(ETourStatus newTourStatus)
    {
        m_selfButton.interactable = !(m_tourManagerScript.CurrentBlockIndex >= (int)m_tourManagerScript.TourConfigurator.TourCompleteStatus);
        gameObject.SetActive(m_tourManagerScript.CurrentBlock != m_notTargetBlock);

    }

    void UpdateButton(GameObject newBlockObject)
    {
        m_selfButton.interactable = !(m_tourManagerScript.CurrentBlockIndex >= (int)m_tourManagerScript.TourConfigurator.TourCompleteStatus);
        gameObject.SetActive(m_tourManagerScript.CurrentBlock != m_notTargetBlock);

    }
    void OnFinishHandler()
    {
        m_selfButton.interactable = false;
        gameObject.SetActive(true);
    }

    void Destroy()
    {
        m_tourManagerScript.TourConfigurator.OnTourStatusChanged.RemoveListener(OnTourStatusChangedHandler);
        m_tourManagerScript.OnBlockChanged.RemoveListener(OnBlockChangedHandler);
    }
}
