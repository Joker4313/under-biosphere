using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon; // 物品的图标
    public Text quantityText; // 物品的数量

    // 设置物品
    public void SetItem(Item item)
    {
        icon.sprite = item.type.icon;
        quantityText.text = item.quantity.ToString();
    }
}
