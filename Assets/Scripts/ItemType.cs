using UnityEngine;

[System.Serializable]
public class ItemType
{
    public enum Type
    {
        LongTermFood,
        ShortTermFood,
        Medicine,
        Material,
        Tool,
        Equipment,
        Important
    }
    public string name; // 物品名字
    public Sprite icon; // 物品图标
    public string description; // 物品描述
    // ... 其他属性
    public Type type; // 物品类型

}
