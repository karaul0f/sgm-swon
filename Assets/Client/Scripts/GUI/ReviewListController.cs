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

        for (int i = 0; i < 3; i++)
        {
            CreateElement("Иван Зай", "Ну ты и лах");
        }
    }
}
