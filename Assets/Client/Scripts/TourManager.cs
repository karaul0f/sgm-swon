using System.Collections;
using System.Collections.Generic;
using Assets.Client.Scripts.Services.Interfaces;
using UnityEngine;
using Zenject;
using UnityEngine.Events;

public class TourManager : MonoBehaviour
{
    public List<GameObject> m_blocks;

    private ITravelService _travelService;

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
    /// ������� ���� ������ ����, � ������� �� ���������.
    /// </summary>
    public TourConfigurator TourConfigurator
    {
        get => m_tourConfigurator;
    }

    /// <summary>
    /// ������� ���� ������ ����, � ������� �� ���������.
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
    /// ������� ������ ����� ����, � ������� �� ���������.
    /// </summary>
    public uint CurrentBlockIndex
    {
        get => m_currentBlockIndex;
    }

    // TODO: Убрать за ненадобностью. Пример использования.
    [Inject]
    public void Construct(ITravelService travelService)
    {
        _travelService = travelService;
    }

    void Awake()
    {
        m_worldLoader = gameObject.GetComponent<WorldLoader>();

        if (m_onBlockChanged == null)
            m_onBlockChanged = new UnityEvent<GameObject>();

        m_tourConfigurator = new TourConfigurator(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentBlock = m_blocks[0];
    }
}
