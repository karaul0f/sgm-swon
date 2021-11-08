using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    protected GameObject m_tourManager;
    protected ListController m_listController;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        m_tourManager = GameObject.FindGameObjectWithTag("TourManager");
        m_listController = gameObject.GetComponent<ListController>();
        TourManager tourManagerScript = m_tourManager.GetComponent(typeof(TourManager)) as TourManager;
        tourManagerScript.TourConfigurator.OnTourStatusChanged.AddListener(OnTourStatusChangedHandler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnTourStatusChangedHandler(ETourStatus newTourStatusValue)
    {
        m_listController.UpdateItems();
    }
}


