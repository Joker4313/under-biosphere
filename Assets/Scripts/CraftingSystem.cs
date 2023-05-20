using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CraftingSystem : MonoBehaviour

{
    private Button button;
    private string result;
    private List<CraftingIngredient> requiredItems;
    
    void Awake(){
        button = GetComponent<Button>();
        result = GetComponent<CraftingRecipe>().result;
        requiredItems = GetComponent<CraftingRecipe>().requiredItems;
        button.onClick.AddListener(() => Craft(result, requiredItems));
    }
    public void Craft(string result, List<CraftingIngredient> requiredItems)
    {
        // 检查每个必要的物品
        foreach (CraftingIngredient ingredient in requiredItems)
        {
            if (Inventory.Instance.GetItemCount(ingredient.name) < ingredient.quantity)
            {
                // 如果没有足够的物品，返回false

            }
        }

        // 有足够的物品，因此我们从背包中移除它们并添加结果物品
        foreach (CraftingIngredient ingredient in requiredItems)
        {
            Inventory.Instance.RemoveItem(ingredient.name, ingredient.quantity);
        }

        // 向背包中添加结果物品
        Inventory.Instance.AddItem(result, 1);

        // 合成成功，返回true

    }
}
