using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ListController : MonoBehaviour
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
    protected GameObject CreateElement(string name)
    {
        GameObject obj = Instantiate<GameObject>(
            ListItemPrefab, transform);

        obj.transform.position =
            new Vector3(obj.transform.position.x, obj.transform.position.y + ElementDistance * m_elements.Count);

        obj.GetComponent<ListItemController>().Name.text = name;

        m_elements.Add(obj);

        return obj;
    }
    protected GameObject CreateElement(string name, string description, string price, string imagePath)
    {
        byte[] fileData;
        price = "Цена: " + price + "$";
        imagePath = @"Assets\Client\Images\UI\" + imagePath;

        GameObject obj = Instantiate<GameObject>(
            ListItemPrefab, transform);

        obj.transform.position =
            new Vector3(obj.transform.position.x, obj.transform.position.y + ElementDistance * m_elements.Count);

        obj.GetComponent<ListItemController>().Name.text = name;
        //obj.GetComponent<ListItemController>().Description.text = description;
        obj.GetComponent<ListItemController>().Price.text = price;

        if (File.Exists(imagePath))
        {
            fileData = File.ReadAllBytes(imagePath);
            var texture = new Texture2D(2, 2);

            if (texture.LoadImage(fileData))
                obj.GetComponent<ListItemController>().Icon.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
        }

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

    virtual public void SelectItem(int index)
    {

    }
}
