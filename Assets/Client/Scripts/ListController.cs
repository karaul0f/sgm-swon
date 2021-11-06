using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ListController : MonoBehaviour
{
    [SerializeField] private GameObject m_tourManager;
    private TourManager m_tourManagerScript;

    public GameObject ListItemPrefab;
    public int ElementDistance;

    private int m_countVisualElements;

    // Start is called before the first frame update
    void Start()
    {
        m_countVisualElements = 0;
        m_tourManagerScript = m_tourManager.GetComponent<TourManager>();

        foreach (var county in m_tourManagerScript.Countries)
        {
            CreateElement(county.Value.Name);
        }
    }

    GameObject CreateElement(string name)
    {
        GameObject obj = Instantiate<GameObject>(
            ListItemPrefab, transform);

        obj.transform.position =
            new Vector3(obj.transform.position.x, obj.transform.position.y + ElementDistance * m_countVisualElements);

        obj.GetComponent<ListItemController>().Name.text = name;

        m_countVisualElements++;

        return obj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
