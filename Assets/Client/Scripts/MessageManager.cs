using UnityEngine;
using UnityEngine.Events;

public class MessageManager : MonoBehaviour
{
    private UnityEvent<EMessageType, string> m_onMessageAdded;

    // Start is called before the first frame update
    void Awake()
    {
        if (m_onMessageAdded == null)
            m_onMessageAdded = new UnityEvent<EMessageType, string>();
    }

    public UnityEvent<EMessageType, string> OnMessageAdded
    {
        get => m_onMessageAdded;
    }

    public void AddMessage(EMessageType messageType, string text)
    {
        m_onMessageAdded.Invoke(messageType, text);
        Debug.Log("MessageManager::AddMessage(" + text + ")");
    }
}
