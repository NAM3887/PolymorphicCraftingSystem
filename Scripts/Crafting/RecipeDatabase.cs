using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RecipeDatabase : MonoBehaviour
{
    public static RecipeDatabase Instance;

    public List<BaseRecipeSO> allRecipes;

    private void Awake()
    {
        Instance = this;
    }
    
    public List<CraftingRecipeSO> GetCraftingRecipes()
        => allRecipes.OfType<CraftingRecipeSO>().ToList();

    public List<JunkRecipeSO> GetJunkRecipes()
        => allRecipes.OfType<JunkRecipeSO>().ToList();

    public List<BaseRecipeSO> GetAllCraftable(InventoryManager inv)
        => allRecipes.Where(r => r.CanCraft(inv)).ToList();
}