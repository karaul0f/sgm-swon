using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Capital : MonoBehaviour
{
    [SerializeField] private int m_money;

    private UnityEvent<int> m_onMoneyChanged;

    public int Money
    {
        get => m_money;
        set 
        { 
            m_money = value;
            m_onMoneyChanged.Invoke(m_money);
        }
    }

    public UnityEvent<int> OnMoneyChanged
    {
        get => m_onMoneyChanged;
    }

    void Awake()
    {
        if (m_onMoneyChanged == null)
            m_onMoneyChanged = new UnityEvent<int>();

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
