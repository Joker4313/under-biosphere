using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance { get; private set; }

    private List<Item> items; // 背包中的物品
    public InventoryUI inventoryUI; // 背包的 UI

    private void Start()
    {
        // 初始化背包
        items = new List<Item>();

        AddTestItems();
        // 更新背包 UI
        UpdateUI();
    }

    // 添加物品
    public void AddItem(string name, int quantity)
    {
        // 查找物品
        Item item = items.Find(i => i.type.name == name);

        // 如果物品已存在，增加数量
        if (item != null)
        {
            item.quantity += quantity;
            Debug.Log("item exists, Add " + quantity + " " + name);
        }
        // 否则，添加新物品
        else
        {
            ItemType itemType = ItemDatabase.Instance.GetItemTypeByName(name);
            items.Add(new Item(itemType, quantity));
            Debug.Log("item not exists, Add " + quantity + " " + name);
        }

        // 重新排序物品
        SortItems();

        // 更新背包 UI
        UpdateUI();
    }

    // 移除物品
    public void RemoveItem(string name, int quantity)
    {
        // 查找物品
        Item item = items.Find(i => i.type.name == name);

        // 如果物品存在，减少数量
        if (item != null)
        {
            item.quantity -= quantity;

            // 如果数量为 0，删除物品
            if (item.quantity <= 0)
            {
                items.Remove(item);
            }

            // 重新排序物品
            SortItems();

            // 更新背包 UI
            UpdateUI();
        }
    }

    // 排序物品（按数量从高到低排序）
    public void SortItems()
    {
        items.Sort((item1, item2) => item2.quantity.CompareTo(item1.quantity));
    }

    // 更新背包 UI
    public void UpdateUI()
    {
        inventoryUI.UpdateUI(items);
    }


    public void AddTestItems()
    {
        AddItem("Chocolate", 10);
        AddItem("Barrel", 5);
        AddItem("Lighter", 20);
    }
}
