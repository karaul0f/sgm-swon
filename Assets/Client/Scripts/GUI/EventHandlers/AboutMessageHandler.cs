using UnityEngine;
using UnityEngine.UI;

public class AboutMessageHandler : MonoBehaviour
{
    private GameObject m_gameManager;
    private MessageManager m_messageManager;
    [SerializeField] private Text m_aboutText;
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
        if (type == EMessageType.AboutMessage)
        {
            m_aboutText.text = text;
            gameObject.SetActive(true);
        }

    }

    void Destroy()
    {
        m_messageManager.OnMessageAdded.RemoveListener(OnMessageAdded);
    }
}
