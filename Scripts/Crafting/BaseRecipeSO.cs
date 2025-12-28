using UnityEngine;

// Recipe Base class Crafting recipe and JunkRecipe Will inherit from this class 
public abstract class BaseRecipeSO : ScriptableObject
{
    public string recipeName;
 
    public Sprite icon;
    // Can the player craft/scrap with this recipe
    public abstract bool CanCraft(InventoryManager inv);

    // Executes the crafting/scrapping logic
    public abstract void Craft(InventoryManager inv);
}

