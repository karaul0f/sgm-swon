using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsHandler : MonoBehaviour
{
    [SerializeField] private Text m_name;
    [SerializeField] private Text m_text;

    // Start is called before the first frame update
    void Start()
    {
        m_name.text = $"Новость дня:";
        m_text.text = $"Это её отсутствие";
    }
}
