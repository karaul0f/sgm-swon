using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TourManager : MonoBehaviour
{
    public List<GameObject> m_blocks;

    private GameObject m_currentBlock;
    private uint m_currentBlockIndex;
    private WorldLoader m_worldLoader;

    private UnityEvent<GameObject> m_onBlockChanged;

    public List<Person> Persons { get { return m_worldLoader.Persons; } }
    public Dictionary<string, Country> Countries { get { return m_worldLoader.Countries; } }

    public void OnNextClick()
    {
        m_currentBlockIndex = (uint) ((m_currentBlockIndex  + 1) % m_blocks.Count);
        CurrentBlock = m_blocks[(int) m_currentBlockIndex];
    }

    public void OnBackClick()
    {
        m_currentBlockIndex = (uint)((m_currentBlockIndex - 1) % m_blocks.Count);
        CurrentBlock = m_blocks[(int)m_currentBlockIndex];
    }

    public UnityEvent<GameObject> OnBlockChanged
    {
        get => m_onBlockChanged;
    }

    public GameObject CurrentBlock
    {
        get => m_currentBlock;
        private set
        {
            m_currentBlock = value;
            m_onBlockChanged.Invoke(m_currentBlock);
        }
    }

    void Awake()
    {
        m_worldLoader = gameObject.GetComponent<WorldLoader>();

        if (m_onBlockChanged == null)
            m_onBlockChanged = new UnityEvent<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentBlock = m_blocks[0];
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    void Destroy()
    {

    }
}
