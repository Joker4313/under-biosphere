using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinableItemBehaviour : MonoBehaviour
{
    public int minableId = 0;
    public string minableNote = "???";
    public string minableNoteUndercon = "???";
    public float minableAmount = 10f;
    public float highlightLevel = 1.5f;
    public bool isDoor = false;
    public int doorId = 0;
    public int[] requireList = new int[0];

    float miningProgress = 0;

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

    public bool underCondition()
    {
        //TODO
        //待补充，判断是否满足开采/开门条件
        //TODO
        return true;
    }

    public bool Mine(float increasing)
    {
        miningProgress += increasing;
        return miningProgress >= minableAmount;
    }

    public float getProgress()
    {
        return miningProgress / minableAmount;
    }

    void Start()
    {
        gameObject.tag = "Minable";
        gameObject.AddComponent<SphereCollider>();
        gameObject.GetComponent<SphereCollider>().center = new Vector3(0, 0, 0);
        gameObject.GetComponent<SphereCollider>().radius = 0.95f / System.Math.Max(transform.localScale.z, System.Math.Max(transform.localScale.x, transform.localScale.y));
        gameObject.GetComponent<SphereCollider>().isTrigger = true;
    }

    void Update()
    {

    }
}
