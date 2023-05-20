using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickBehavior : MonoBehaviour
{
    Dictionary<GameObject, float> pickableDic = new Dictionary<GameObject, float>();
    GameObject nearestInteractable = null;
    float nearestDistance = 10000;

    public string nextSceneName;
    public GameObject UISupport;
    public float miningRate = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && nearestInteractable != null)
            if (nearestInteractable.GetComponent<PickableItemBehaviour>() != null)
            {
                //TODO
                //Put this item into the item list
                //未完成-将离自己最近的可采集物品放入背包（nearestPickable）
                //TODO

                UISupport.GetComponent<UISupporter>().closeNotice();
                pickableDic.Remove(nearestInteractable);
                Destroy(nearestInteractable);
                nearestInteractable = null;
                nearestDistance = 10000;
            }

        if (OVRInput.Get(OVRInput.Button.One) && nearestInteractable != null)
            if (nearestInteractable.GetComponent<MinableItemBehaviour>() != null)
            {
                if (nearestInteractable.GetComponent<MinableItemBehaviour>().Mine(miningRate * Time.fixedDeltaTime))
                {
                    if (nearestInteractable.GetComponent<MinableItemBehaviour>().isDoor)
                    {
                        SceneManager.LoadScene(nextSceneName);
                    }
                    else
                    {
                        //TODO
                        //Put this item into the item list
                        //未完成-将开采物品放入背包（nearestMinable）
                        //TODO
                        UISupport.GetComponent<UISupporter>().closeNotice();
                        pickableDic.Remove(nearestInteractable);
                        Destroy(nearestInteractable);
                        nearestInteractable = null;
                        nearestDistance = 10000;
                    }
                }
                else
                    UISupport.GetComponent<UISupporter>().itemNotice(nearestInteractable.GetComponent<MinableItemBehaviour>().minableNoteUndercon + " " + string.Format("{0:f2}", nearestInteractable.GetComponent<MinableItemBehaviour>().getProgress() * 100) + "%");




            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.CompareTo("Pickable") == 0 || other.gameObject.tag.CompareTo("Minable") == 0)
        {
            pickableDic.Add(other.gameObject, (other.transform.position - transform.position).magnitude);
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.CompareTo("Pickable") == 0)
        {
            foreach (KeyValuePair<GameObject, float> pair in pickableDic)
                if (pair.Value < nearestDistance)
                {
                    if (nearestInteractable != null)
                        nearestInteractable.GetComponent<PickableItemBehaviour>().CancelHighlight();
                    nearestInteractable = pair.Key;
                    nearestDistance = pair.Value;
                    nearestInteractable.GetComponent<PickableItemBehaviour>().Highlight();
                    UISupport.GetComponent<UISupporter>().itemNotice(nearestInteractable.GetComponent<PickableItemBehaviour>().itemName);
                }
        }

        if (other.gameObject.tag.CompareTo("Minable") == 0)
        {
            foreach (KeyValuePair<GameObject, float> pair in pickableDic)
                if (pair.Value < nearestDistance)
                {
                    if (nearestInteractable != null)
                        nearestInteractable.GetComponent<MinableItemBehaviour>().CancelHighlight();
                    nearestInteractable = pair.Key;
                    nearestDistance = pair.Value;
                    nearestInteractable.GetComponent<MinableItemBehaviour>().Highlight();
                    if (nearestInteractable.GetComponent<MinableItemBehaviour>().underCondition()) //条件和方法参数待补充
                        UISupport.GetComponent<UISupporter>().itemNotice(nearestInteractable.GetComponent<MinableItemBehaviour>().minableNoteUndercon + " " + string.Format("{0:f2}", nearestInteractable.GetComponent<MinableItemBehaviour>().getProgress() * 100) + "%");
                    else
                        UISupport.GetComponent<UISupporter>().itemNotice(nearestInteractable.GetComponent<MinableItemBehaviour>().minableNote);
                }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.CompareTo("Pickable") == 0)
        {
            other.gameObject.GetComponent<PickableItemBehaviour>().CancelHighlight();
            UISupport.GetComponent<UISupporter>().closeNotice();
            pickableDic.Remove(other.gameObject);
            nearestInteractable = null;
            nearestDistance = 10000;
        }

        if (other.gameObject.tag.CompareTo("Minable") == 0)
        {
            other.gameObject.GetComponent<MinableItemBehaviour>().CancelHighlight();
            UISupport.GetComponent<UISupporter>().closeNotice();
            pickableDic.Remove(other.gameObject);
            nearestInteractable = null;
            nearestDistance = 10000;
        }
    }
}
