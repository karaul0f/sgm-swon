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

    private TourConfigurator m_tourConfigurator;

    private UnityEvent<GameObject> m_onBlockChanged;

    public List<Person> Persons { get { return m_worldLoader.Persons; } }
    public Dictionary<string, Country> Countries { get { return m_worldLoader.Countries; } }

    public void OnNextClick()
    {
        if (m_currentBlockIndex < (int)m_tourConfigurator.TourCompleteStatus)
        {
            m_currentBlockIndex = m_currentBlockIndex + 1;
            CurrentBlock = m_blocks[(int)m_currentBlockIndex];
        }
    }

    public void OnBackClick()
    {
        if (m_currentBlockIndex > 0)
        {
            m_currentBlockIndex = m_currentBlockIndex - 1;
            CurrentBlock = m_blocks[(int) m_currentBlockIndex];
        }
    }

    public UnityEvent<GameObject> OnBlockChanged
    {
        get => m_onBlockChanged;
    }

    /// <summary>
    /// “екущий блок выбора тура, в котором мы находимс€.
    /// </summary>
    public TourConfigurator TourConfigurator
    {
        get => m_tourConfigurator;
    }

    /// <summary>
    /// “екущий блок выбора тура, в котором мы находимс€.
    /// </summary>
    public GameObject CurrentBlock
    {
        get => m_currentBlock;
        private set
        {
            m_currentBlock = value;
            m_onBlockChanged.Invoke(m_currentBlock);
        }
    }

    /// <summary>
    /// “екущий индекс блока тура, в котором мы находимс€.
    /// </summary>
    public uint CurrentBlockIndex
    {
        get => m_currentBlockIndex;
    }

    void Awake()
    {
        m_worldLoader = gameObject.GetComponent<WorldLoader>();

        if (m_onBlockChanged == null)
            m_onBlockChanged = new UnityEvent<GameObject>();

        m_tourConfigurator = new TourConfigurator();
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentBlock = m_blocks[0];
    }
}
