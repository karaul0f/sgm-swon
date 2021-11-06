using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBlockHandler : MonoBehaviour
{
    [SerializeField] private GameObject m_tourManager;

    // Start is called before the first frame update
    void Start()
    {
        TourManager tourManagerScript = m_tourManager.GetComponent(typeof(TourManager)) as TourManager;
        tourManagerScript.OnBlockChanged.AddListener(OnBlockChangedHandler);

        if(tourManagerScript.CurrentBlock != null)
            OnBlockChangedHandler(tourManagerScript.CurrentBlock);
    }

    void OnBlockChangedHandler(GameObject newBlockValue)
    {
        gameObject.SetActive(newBlockValue == gameObject);
    }
}
