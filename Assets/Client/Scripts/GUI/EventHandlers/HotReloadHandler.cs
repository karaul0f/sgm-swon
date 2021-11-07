using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HotReloadHandler : MonoBehaviour
{
    [SerializeField] private Button m_button;

    // Start is called before the first frame update
    void Start()
    {
        m_button.onClick.AddListener(OnClockHandler);
    }

    // Update is called once per frame
    void OnClockHandler()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Destroy()
    {
        m_button.onClick.RemoveListener(OnClockHandler);
    }
}
