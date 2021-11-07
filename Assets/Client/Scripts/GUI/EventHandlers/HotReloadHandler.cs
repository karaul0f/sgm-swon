using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HotReloadHandler : MonoBehaviour
{
    [SerializeField] private Button m_button;
    [SerializeField] private Button m_exitButton;

    // Start is called before the first frame update
    void Start()
    {
        if(m_button != null)
            m_button.onClick.AddListener(OnClockHandler);

        if(m_exitButton != null)
            m_exitButton.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    public void OnClockHandler()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

    void Destroy()
    {
        m_button.onClick.RemoveListener(OnClockHandler);
    }
}
