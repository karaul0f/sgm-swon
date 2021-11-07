using System.Collections.Generic;
using Assets.Client.Scripts.Services.Interfaces;
using JetBrains.Annotations;
using UnityEngine;
using Assets.Client.Scripts.Data;
using UnityEngine.Events;

/// <summary>
/// Конфигуратор тура
/// </summary>
public class TourConfigurator
{
    private ETourStatus m_tourStatus;
    private UnityEvent<ETourStatus> m_onTourStatusChanged;
    private UnityEvent<int> m_onCostChanged;
    private TourManager m_tourManagerScript;
    private Tour m_tour;
    private int m_currentTourCost;
    private ITourProvider _tourProvider;

    void RecalculateCost()
    {
        int newCostValue = 0;

        if (m_tour != null && m_tour.Hotel != null)
            newCostValue += m_tour.Hotel.Price;

        if (m_tour != null && m_tour.Excursion != null)
            newCostValue += m_tour.Excursion.Price;

        if (m_tour != null && m_tour.Transfer != null)
            newCostValue += m_tour.Transfer.Price;

        CurrentTourCost = newCostValue;
    }

    public UnityEvent<ETourStatus> OnTourStatusChanged
    {
        get => m_onTourStatusChanged;
    }

    public UnityEvent<int> OnCostChanged
    {
        get => m_onCostChanged;
    }

    public TourConfigurator(TourManager tourManager, ITourProvider tourProvider)
    {
        m_tour = new Tour();
        m_tourManagerScript = tourManager;
        _tourProvider = tourProvider;

        if (m_onTourStatusChanged == null)
            m_onTourStatusChanged = new UnityEvent<ETourStatus>();

        if (m_onCostChanged == null)
            m_onCostChanged = new UnityEvent<int>();
    }

    /// <summary>
    /// Текущий статус оформления тура.
    /// </summary>
    public ETourStatus TourCompleteStatus
    {
        get => m_tourStatus;
        private set
        {
            m_tourStatus = value;
            m_onTourStatusChanged.Invoke(m_tourStatus);
        }
    }

    /// <summary>
    /// Текущая стоимость тура.
    /// </summary>
    public int CurrentTourCost
    {
        get => m_currentTourCost;
        private set
        {
            m_currentTourCost = value;
            m_onCostChanged.Invoke(m_currentTourCost);
        }
    }

    /// <summary>
    /// Начинаем конфигурацию сначала
    /// </summary>
    public void ResetTourConfiguration()
    {
        m_tour = new Tour();
        TourCompleteStatus = ETourStatus.NothingSelected;
        RecalculateCost();
    }

    /// <summary>
    /// Выбрать страну, в которую отправим.
    /// </summary>
    /// <param name="county"></param>
    public void SelectCounty(string county)
    {
        m_tour.Country = m_tourManagerScript.Countries[county];
        TourCompleteStatus = ETourStatus.CountrySelected;
        RecalculateCost();
    }

    /// <summary>
    /// Выбрать трансфер.
    /// </summary>
    /// <param name="transfer"></param>
    public void SelectTransfer(string transfer)
    {
        m_tour.Transfer = m_tourManagerScript.Countries[m_tour.Country.Name].Transfers[transfer];
        TourCompleteStatus = ETourStatus.TransferSelected;
        RecalculateCost();
    }

    /// <summary>
    /// Выбрать гостиницу.
    /// </summary>
    /// <param name="hotel"></param>
    public void SelectHotel(string hotel)
    {
        m_tour.Hotel = m_tourManagerScript.Countries[m_tour.Country.Name].Hotels[hotel];
        TourCompleteStatus = ETourStatus.HotelSelected;
        RecalculateCost();
    }

    /// <summary>
    /// Выбрать экскурсию.
    /// </summary>
    /// <param name="excursion"></param>
    public void SelectExcursion(string excursion)
    {
        m_tour.Excursion = m_tourManagerScript.Countries[m_tour.Country.Name].Excursions[excursion];
        TourCompleteStatus = ETourStatus.Final;
        RecalculateCost();
    }

    public Country SelectedCountry
    {
        get => m_tour.Country;
    }

    public Transfer SelectedTransfer
    {
        get => m_tour.Transfer;
    }

    public Excursion SelectedExcursion
    {
        get => m_tour.Excursion;
    }

    public Hotel SelectedHotel
    {
        get => m_tour.Hotel;
    }

    /// <summary>
    /// Выполнить создание тура
    /// </summary>
    void CreateTour()
    {

    }

    /// <summary>
    /// Получить доступные для выбора страны
    /// </summary>
    public IEnumerable<Country> AvailableCounties => _tourProvider.GetAvailableCountries();// m_tourManagerScript.Countries?.Values;

    /// <summary>
    /// Получить доступный для выбора трансфер/трансферы
    /// </summary>
    public IEnumerable<Transfer> AvailableTransfers
    {
        get => m_tour.Country != null ? m_tour.Country.Transfers.Values : null;
    }

    /// <summary>
    /// Получить доступный для выбора отели
    /// </summary>
    public IEnumerable<Hotel> AvailableHotels
    {
        get => m_tour.Country != null ? m_tour.Country.Hotels.Values : null;
    }

    /// <summary>
    /// Получить доступный для выбора экскурсии
    /// </summary>
    public IEnumerable<Excursion> AvailableExcursions
    {
        get => m_tour.Country != null ? m_tour.Country.Excursions.Values : null;
    }

}
