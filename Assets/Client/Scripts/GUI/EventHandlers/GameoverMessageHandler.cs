using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverMessageHandler : MonoBehaviour
{
    private GameObject m_gameManager;
    private MessageManager m_messageManager;
    [SerializeField] private Text m_gameoverText;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        m_gameManager = GameObject.FindWithTag("GameManager");
        m_messageManager = m_gameManager.GetComponent<MessageManager>();
        m_messageManager.OnMessageAdded.AddListener(OnMessageAdded);
    }

    void OnMessageAdded(EMessageType type, string text)
    {
        if (type == EMessageType.ResultMessage)
        {
            m_gameoverText.text = text;
            gameObject.SetActive(true);
        }
    }

    void Destroy()
    {
        m_messageManager.OnMessageAdded.RemoveListener(OnMessageAdded);
    }
}
