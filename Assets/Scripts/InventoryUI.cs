using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab; // 物品槽的预制体
    public Transform itemSlotContainer; // 物品槽的容器

    // 更新背包 UI
    public void UpdateUI(List<Item> items)
    {
        // 清空当前的物品槽
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }

        // 为每个物品创建一个新的物品槽
        foreach (Item item in items)
        {
            // 创建物品槽
            GameObject itemSlot = Instantiate(itemSlotPrefab, itemSlotContainer);

            // 设置物品槽的图标和数量
            itemSlot.GetComponent<ItemSlot>().SetItem(item);
        }
    }
}
