using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
   public static ItemDatabase Instance { get; private set; }

    public List<ItemType> itemTypes;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public ItemType GetItemTypeByName(string name)
    {
        return itemTypes.Find(itemType => itemType.name == name);
    }
}
