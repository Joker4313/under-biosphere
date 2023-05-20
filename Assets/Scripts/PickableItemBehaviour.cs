using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemBehaviour : MonoBehaviour
{
    public int itemId = 0;
    public string itemName = "Item";
    public float highlightLevel = 1.5f;
    public bool isNote = false;
    public int noteId = 0;

    public void Highlight()
    {
        if (gameObject.GetComponent<Renderer>() != null)
        {
            Color c = gameObject.GetComponent<Renderer>().material.color;
            c.r *= highlightLevel;
            c.g *= highlightLevel;
            c.b *= highlightLevel;
            gameObject.GetComponent<Renderer>().material.color = c;
        }
        else
            Highlight(gameObject);
    }

    public void CancelHighlight()
    {
        if (gameObject.GetComponent<Renderer>() != null)
        {
            Color c = gameObject.GetComponent<Renderer>().material.color;
            c.r /= highlightLevel;
            c.g /= highlightLevel;
            c.b /= highlightLevel;
            gameObject.GetComponent<Renderer>().material.color = c;
        }
        else
            CancelHighlight(gameObject);
    }

    void Highlight(GameObject father)
    {
        foreach (Transform t in father.GetComponentInChildren<Transform>())
        {
            if (t.gameObject.GetComponent<Renderer>() != null)
            {
                Color c = t.gameObject.GetComponent<Renderer>().material.color;
                c.r *= highlightLevel;
                c.g *= highlightLevel;
                c.b *= highlightLevel;
                t.gameObject.GetComponent<Renderer>().material.color = c;
            }
            else
                Highlight(t.gameObject);
        }
    }

    void CancelHighlight(GameObject father)
    {
        foreach (Transform t in father.GetComponentInChildren<Transform>())
        {
            if (t.gameObject.GetComponent<Renderer>() != null)
            {
                Color c = t.gameObject.GetComponent<Renderer>().material.color;
                c.r /= highlightLevel;
                c.g /= highlightLevel;
                c.b /= highlightLevel;
                t.gameObject.GetComponent<Renderer>().material.color = c;
            }
            else
                CancelHighlight(t.gameObject);
        }
    }

    void Start()
    {
        gameObject.tag = "Pickable";
        gameObject.AddComponent<SphereCollider>();
        gameObject.GetComponent<SphereCollider>().center = new Vector3(0, 0, 0);
        gameObject.GetComponent<SphereCollider>().radius = 0.85f / System.Math.Max(transform.localScale.z, System.Math.Max(transform.localScale.x, transform.localScale.y));
        gameObject.GetComponent<SphereCollider>().isTrigger = true;
    }

    void Update()
    {
        
    }
}
