using System;
using System.Collections.Generic;
using Assets.Client.Scripts.Data;
using Assets.Client.Scripts.Services.Interfaces;
using UnityEngine;
using Zenject;
using UnityEngine.Events;

public class TourManager : MonoBehaviour
{
    public List<GameObject> m_blocks;

    private ITravelService _travelService;
    private ITourProvider _tourProvider;
    private IGenerator<Person> _personGenerator;

    private GameObject m_currentBlock;
    private uint m_currentBlockIndex;
    private WorldLoader m_worldLoader;
    private GameObject m_gameManager;

    private MessageManager m_messageManager;

    private Person m_currentClient;

    private TourConfigurator m_tourConfigurator;

    private UnityEvent<GameObject> m_onBlockChanged;

    private UnityEvent m_onFinishTour;
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

    public UnityEvent OnFinishTour
    {
        get => m_onFinishTour;
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

    public void FinishTour(int TourCost)
    {
        var travelResult = _travelService.GetTravelResults(m_tourConfigurator.MakeTour(), _personGenerator.Current);
        var capital = m_gameManager.GetComponent<Capital>().Money;
        int resultSum = travelResult.Reward - TourCost;
        m_gameManager.GetComponent<Capital>().Money += resultSum;

        if (m_gameManager.GetComponent<Capital>().Money < 0)
        {
            m_messageManager.AddMessage(EMessageType.ResultMessage, "Вы полностью разорились!");
            return;
        }

        if (m_gameManager.GetComponent<Capital>().Money > 100000)
        {
            m_messageManager.AddMessage(EMessageType.ResultMessage, "Вы достаточно богаты. Поздравляем!");
            return;
        }



        string resultText = travelResult.Message;
        resultText += "\n\nЧто случилось:\n";
        foreach (var travelResultEvent in travelResult.Events)
        {
            if (travelResultEvent.Name != null)
                resultText += travelResultEvent.Name + '\n';
        }

        int absResult = Math.Abs(resultSum);
        resultText += (resultSum) >= 0 ? $"\n Вы заработали: {resultSum}$" : $"\n Вы потеряли: {absResult}";
        m_messageManager.AddMessage(EMessageType.AboutMessage,
            resultText);

        m_tourConfigurator.ResetTourConfiguration();
        m_currentBlockIndex = 0;
        CurrentBlock = m_blocks[0];
        m_onFinishTour.Invoke();
        _personGenerator.Next();
    }

    // TODO: Убрать за ненадобностью. Пример использования.
    [Inject]
    public void Construct(ITravelService travelService, ITourProvider tourProvider, IGenerator<Person> personGenerator)
    {
        _travelService = travelService;
        _tourProvider = tourProvider;
        _personGenerator = personGenerator;

        m_currentClient = _personGenerator.Current;

        var test = _tourProvider.GetAvailableCountries();
    }

    public Person CurrentClient
    {
        get => m_currentClient;
    }

    void Awake()
    {
        m_worldLoader = gameObject.GetComponent<WorldLoader>();

        if (m_onBlockChanged == null)
            m_onBlockChanged = new UnityEvent<GameObject>();

        if (m_onFinishTour == null)
            m_onFinishTour = new UnityEvent();

        m_tourConfigurator = new TourConfigurator(this, _tourProvider);
    }

    void Start()
    {
        CurrentBlock = m_blocks[0];
        m_gameManager = GameObject.FindWithTag("GameManager");
        m_messageManager = m_gameManager.GetComponent<MessageManager>();
    }
}
