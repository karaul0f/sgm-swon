using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ������������ ����
/// </summary>
public class TourConfigurator
{
    private ETourStatus m_tourStatus;
    private UnityEvent<ETourStatus> m_onTourStatusChanged;
    private TourManager m_tourManagerScript;
    private Tour m_tour;

    public UnityEvent<ETourStatus> OnTourStatusChanged
    {
        get => m_onTourStatusChanged;
    }

    public TourConfigurator(TourManager tourManager)
    {
        m_tour = new Tour();
        m_tourManagerScript = tourManager;

        if (m_onTourStatusChanged == null)
            m_onTourStatusChanged = new UnityEvent<ETourStatus>();
    }

    /// <summary>
    /// ������� ������ ���������� ����.
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
    /// ������� ������, � ������� ��������.
    /// </summary>
    /// <param name="county"></param>
    public void SelectCounty(string county)
    {
        m_tour.Country = m_tourManagerScript.Countries[county];
        TourCompleteStatus = ETourStatus.CountrySelected;
    }

    /// <summary>
    /// ������� ��������.
    /// </summary>
    /// <param name="transfer"></param>
    public void SelectTransfer(string transfer)
    {
        m_tour.Transfer = m_tourManagerScript.Countries[m_tour.Country.Name].Transfers[transfer];
        TourCompleteStatus = ETourStatus.TransferSelected;
    }

    /// <summary>
    /// ������� ���������.
    /// </summary>
    /// <param name="hotel"></param>
    public void SelectHotel(string hotel)
    {
        m_tour.Hotel = m_tourManagerScript.Countries[m_tour.Country.Name].Hotels[hotel];
        TourCompleteStatus = ETourStatus.HotelSelected;
    }

    /// <summary>
    /// ������� ���������.
    /// </summary>
    /// <param name="excursion"></param>
    public void SelectExcursion(string excursion)
    {
        m_tour.Excursion = m_tourManagerScript.Countries[m_tour.Country.Name].Excursions[excursion];
        TourCompleteStatus = ETourStatus.Final;
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
    /// ��������� �������� ����
    /// </summary>
    void CreateTour()
    {

    }

    /// <summary>
    /// �������� ��������� ��� ������ ������
    /// </summary>
    public IEnumerable<Country> AvailableCounties => m_tourManagerScript.Countries?.Values;

    /// <summary>
    /// �������� ��������� ��� ������ ��������/���������
    /// </summary>
    public IEnumerable<Transfer> AvailableTransfers
    {
        get => m_tour.Country != null ? m_tour.Country.Transfers.Values : null;
    }

    /// <summary>
    /// �������� ��������� ��� ������ �����
    /// </summary>
    public IEnumerable<Hotel> AvailableHotels
    {
        get => m_tour.Country != null ? m_tour.Country.Hotels.Values : null;
    }

    /// <summary>
    /// �������� ��������� ��� ������ ���������
    /// </summary>
    public IEnumerable<Excursion> AvailableExcursions
    {
        get => m_tour.Country != null ? m_tour.Country.Excursions.Values : null;
    }

}
