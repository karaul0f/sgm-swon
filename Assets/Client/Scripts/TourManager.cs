using System.Collections;
using System.Collections.Generic;
using Assets.Client.Scripts.Services.Interfaces;
using UnityEngine;
using Zenject;

public class TourManager : MonoBehaviour
{
    public GameObject GameManager;

    private ITravelService _travelService;

    // TODO: Убрать за ненадобностью. Пример использования.
    [Inject]
    public void Construct(ITravelService travelService)
    {
        _travelService = travelService;
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
