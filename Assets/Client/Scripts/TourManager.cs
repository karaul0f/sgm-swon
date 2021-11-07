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
    private ITourProvider _tourProvider;

    private GameObject m_currentBlock;
    private uint m_currentBlockIndex;
    private WorldLoader m_worldLoader;

    private TourConfigurator m_tourConfigurator;

    private UnityEvent<GameObject> m_onBlockChanged;

    public IEnumerable<Person> Persons => m_worldLoader.Persons;
    public IDictionary<string, Country> Countries => m_worldLoader.Countries;

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
    /// Конфигуратор тура.
    /// </summary>
    public TourConfigurator TourConfigurator
    {
        get => m_tourConfigurator;
    }

    /// <summary>
    /// Текущий блок выбора тура, в котором мы находимся.
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
    /// Текущий индекс блока тура, в котором мы находимся.
    /// </summary>
    public uint CurrentBlockIndex
    {
        get => m_currentBlockIndex;
    }

    public void BeginNewTour()
    {
        m_tourConfigurator.ResetTourConfiguration();
        CurrentBlock = m_blocks[0];
    }

    // TODO: Убрать за ненадобностью. Пример использования.
    [Inject]
    public void Construct(ITravelService travelService, ITourProvider tourProvider)
    {
        _travelService = travelService;
        _tourProvider = tourProvider;

        var test = _tourProvider.GetAvailableCountries();
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
