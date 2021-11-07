using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Client.Scripts.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ClientHandler : MonoBehaviour
{
    //[SerializeField] private GameObject m_client;
    [SerializeField] private List<Texture2D> m_clientTextures;
    private Image m_clientImage;
    private IGenerator<Person> _personGenerator;
    private const string UnityPostfix = "(UnityEngine.Texture2D)";

    [Inject]
    public void Construct(IGenerator<Person> personGenerator)
    {
        _personGenerator = personGenerator;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        m_clientImage = gameObject.GetComponent<Image>();
        _personGenerator.Change += OnPersonChanged;
        OnPersonChanged(this, _personGenerator.Current);
    }

    private void OnPersonChanged(object sender, Person person)
    {
        var currentTexture = m_clientTextures.FirstOrDefault(texture => texture.name == $"{person.Image}");
        m_clientImage.sprite = Sprite.Create(currentTexture, new Rect(0, 0, currentTexture.width, currentTexture.height), new Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
