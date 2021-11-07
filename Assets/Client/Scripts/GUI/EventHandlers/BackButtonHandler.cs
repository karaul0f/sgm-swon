using UnityEngine;
using UnityEngine.UI;

public class BackButtonHandler : MonoBehaviour
{

    [SerializeField] private GameObject m_tourManager;

    private TourManager m_tourManagerScript;
    private Button m_selfButton;

    // Start is called before the first frame update
    void Start()
    {
        m_selfButton = gameObject.GetComponent<Button>();
        m_tourManagerScript = m_tourManager.GetComponent<TourManager>();
        m_tourManagerScript.TourConfigurator.OnTourStatusChanged.AddListener(OnTourStatusChangedHandler);
        m_tourManagerScript.OnBlockChanged.AddListener(OnBlockChangedHandler);
        OnTourStatusChangedHandler(m_tourManagerScript.TourConfigurator.TourCompleteStatus);
        OnBlockChangedHandler(m_tourManagerScript.CurrentBlock);
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
        m_selfButton.interactable = m_tourManagerScript.CurrentBlockIndex > 0;
    }
}
