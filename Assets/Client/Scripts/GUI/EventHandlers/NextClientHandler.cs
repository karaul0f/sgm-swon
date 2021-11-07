using System.Collections;
using System.Collections.Generic;
using Assets.Client.Scripts.Data;
using Assets.Client.Scripts.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class NextClientHandler : MonoBehaviour
{
    private IGenerator<Person> _personGenerator;
    [SerializeField] private Button m_selfButton;

    [Inject]
    public void Construct(IGenerator<Person> personGenerator)
    {
        _personGenerator = personGenerator;

    }

    // Start is called before the first frame update
    void Start()
    {
        m_selfButton.onClick.AddListener(OnClickHandler);
    }

    private void OnClickHandler()
    {
        _personGenerator.Next();
    }

    void Destroy()
    {
        m_selfButton.onClick.RemoveListener(OnClickHandler);
    }
}
