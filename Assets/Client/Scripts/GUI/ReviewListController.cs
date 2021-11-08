using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReviewListController : MonoBehaviour
{
    protected GameObject m_tourManager;
    protected TourManager m_tourManagerScript;

    public GameObject ListItemPrefab;
    public int ElementDistance;

    protected int m_countVisualElements;
    protected List<GameObject> m_elements = new List<GameObject>();

    private string review1 = "Добрый день! Спешу поделиться впечатлениями от поездки. Все было замечательно, море, солнце, погода) Отели очень понравились! " +
        "Сервис хороший, парковка бесплатная и охраняемая). В очень живописном месте).";
    private string review2 = "Добрый день! За последние два года моё самое сильное впечатление осталось от, пожалуй, самого романтического, захватывающего путешествия в морских круизах!" +
        "Спасибо за увлекательное посещение кухни на лайнере. Работа безупречная! ";
    private string review3 = "Добрый день! Все было просто ужасно!!! Отель был отвратителен, номера грязные, санузлов нет, на экскурсии чуть не погиб!!!!11! УЖАСНАЯ КОМПАНИЯ! НЕ РЕКОМЕНДУЮ!";
    private string review4 = "Здравствуйте! Отеля, в который заселила меня турфирма, не существовало( Но алкоэкскурсия была БЕСПОДОБНА!!!!!!";
    private string review5 = "Чудесно отдохнула в Каире! Отель был средненький, но чистый. Первое впечатление от персонала было удручающим, но вскоре я убедилась, что была не права. " +
        "Персонал прекрасный, дружелюбный, услужливый!";

    // Start is called before the first frame update
    protected virtual void Start()
    {
        m_tourManager = GameObject.FindWithTag("TourManager");
        m_countVisualElements = 0;
        m_tourManagerScript = m_tourManager.GetComponent<TourManager>();
        UpdateItems();
    }


    /// <summary>
    /// Добавить элемент в список
    /// </summary>
    /// <param name="name">Заголовок</param>
    /// <returns></returns>
    protected GameObject CreateElement(string name, bool isSelected = false)
    {
        return CreateElement(name, "");
    }
    protected GameObject CreateElement(string name, string description)
    {
        GameObject obj = Instantiate<GameObject>(
            ListItemPrefab, transform);

        obj.transform.position =
            new Vector3(obj.transform.position.x, obj.transform.position.y + ElementDistance * m_elements.Count);

        obj.GetComponent<ListItemController>().Name.text = name;
        obj.GetComponent<ListItemController>().Price.text = description;

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

    public void UpdateItems()
    {
        ClearAll();
        
        CreateElement("Иван Петров", review1);
        CreateElement("Ольга Тишкова", review2);
        CreateElement("Галина Новикова", review3);
        CreateElement("Марк Зарецкий", review4);
        CreateElement("Олег Шутов", review5);
    }
}
