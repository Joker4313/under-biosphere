using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CraftingRecipe: MonoBehaviour
{
    public string result;
    public List<CraftingIngredient> requiredItems = new List<CraftingIngredient>();
}