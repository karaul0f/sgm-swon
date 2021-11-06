using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Конфигуратор тура
/// </summary>
public class TourConfigurator
{
    private ETourStatus m_tourStatus;
    private UnityEvent<ETourStatus> m_onTourStatusChanged;
    public UnityEvent<ETourStatus> OnTourStatusChanged
    {
        get => m_onTourStatusChanged;
    }

    public TourConfigurator()
    {
        if (m_onTourStatusChanged == null)
            m_onTourStatusChanged = new UnityEvent<ETourStatus>();
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
    /// Выбрать страну, в которую отправим.
    /// </summary>
    /// <param name="county"></param>
    void SelectCounty(string county)
    {

    }

    /// <summary>
    /// Выбрать трансфер.
    /// </summary>
    /// <param name="county"></param>
    void SelectTransfer(string transfer)
    {

    }

    /// <summary>
    /// Выполнить создание тура
    /// </summary>
    void CreateTour()
    {

    }

}
