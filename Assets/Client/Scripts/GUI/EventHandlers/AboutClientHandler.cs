using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Assets.Client.Scripts.Data;
using Assets.Client.Scripts.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AboutClientHandler : MonoBehaviour
{
    private IGenerator<Person> _personGenerator;
    [SerializeField] private Text m_name;
    [SerializeField] private Text m_budget;
    [SerializeField] private Text m_phrase;

    [Inject]
    public void Construct(IGenerator<Person> personGenerator)
    {
        _personGenerator = personGenerator;

    }

    // Start is called before the first frame update
    void Start()
    {
        _personGenerator.Change += OnPersonChanged;
        OnPersonChanged(this, _personGenerator.Current);
    }

    private void OnPersonChanged(object sender, Person person)
    {
        m_name.text = $"Имя клиента: {person.Name}";
        m_budget.text = $"Бюджет: {person.Budget}$";
        m_phrase.text = $"Пожелания клиента: {person.Phrase}";
    }

    void Destroy()
    {
        _personGenerator.Change -= OnPersonChanged;
    }
}
