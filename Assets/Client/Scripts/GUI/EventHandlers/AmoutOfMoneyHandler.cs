using UnityEngine;
using UnityEngine.UI;

public class AmoutOfMoneyHandler : MonoBehaviour
{
    public GameObject GameManager;

    private Capital m_capital;
    private Text m_text;

    // Start is called before the first frame update
    void Start()
    {
        m_capital = GameManager.GetComponent(typeof(Capital)) as Capital;
        m_capital.OnMoneyChanged.AddListener(OnMoneyChangedHandler);
        m_text = gameObject.GetComponent(typeof(Text)) as Text;
        OnMoneyChangedHandler(m_capital.Money);
    }

    void OnMoneyChangedHandler(int newMoneyValue)
    {
        m_text.text = '$' + newMoneyValue.ToString();
    }
}
