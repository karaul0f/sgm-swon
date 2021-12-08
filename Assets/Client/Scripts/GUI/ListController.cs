using System.Collections.Generic;
using System.IO;
using Assets.Client.Scripts.Data;
using Assets.Client.Scripts.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ListController : MonoBehaviour
{
    protected IGenerator<Person> _personGenerator;
    protected GameObject m_tourManager;
    protected TourManager m_tourManagerScript;

    public GameObject ListItemPrefab;
    public int ElementDistance;

    protected int m_countVisualElements;
    protected List<GameObject> m_elements = new List<GameObject>();

    [Inject]
    public void Construct(IGenerator<Person> personGenerator)
    {
        _personGenerator = personGenerator;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        m_tourManager = GameObject.FindWithTag("TourManager");
        m_countVisualElements = 0;
        m_tourManagerScript = m_tourManager.GetComponent<TourManager>();
        _personGenerator.Change += OnPersonChanged;
        UpdateItems();
    }

    private void OnPersonChanged(object sender, Person person)
    {
        UpdateItems();
    }

    /// <summary>
    /// Добавить элемент в список
    /// </summary>
    /// <param name="name">Заголовок</param>
    /// <returns></returns>
    protected GameObject CreateElement(string name, bool isSelected = false)
    {
        return CreateElement(name, "", 0, "", isSelected);
    }
    protected GameObject CreateElement(string name, string description, int price, string imagePath, bool isSelected = false)
    {
        var priceText = $"Цена: {price}$";
        imagePath = @"Images/" + Path.GetFileNameWithoutExtension(imagePath);

        GameObject obj = Instantiate<GameObject>(
            ListItemPrefab, transform);

        obj.transform.position =
            new Vector3(obj.transform.position.x, obj.transform.position.y + ElementDistance * m_elements.Count);

        obj.GetComponent<ListItemController>().Name.text = name;
        obj.GetComponent<ListItemController>().Description = description;
        obj.GetComponent<ListItemController>().Price.text = priceText;

        var texture = Resources.Load<Texture2D>(imagePath);
        obj.GetComponent<ListItemController>().Icon.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));

        if (isSelected)
            obj.GetComponent<Image>().color = Color.gray;

        m_elements.Add(obj);

        return obj;
    }

    protected void ClearAll()
    {
        foreach (var element in m_elements)
        {
            Destroy(element);
        }
        m_elements.Clear();
    }

    virtual public void UpdateItems()
    {
       
    }

    protected virtual void Destroy()
    {
        _personGenerator.Change -= OnPersonChanged;
        
    }
}
