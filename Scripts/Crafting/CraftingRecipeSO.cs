using System.Linq;
using UnityEngine;

// Handles Crafting Logic
// inherits from baseRecipeSO
[CreateAssetMenu(fileName = "CraftingRecipe", menuName = "Scriptable Objects/Crafting Recipe")]
public class CraftingRecipeSO : BaseRecipeSO
{
    public CraftingComponent[] requiredComponents;
    public Item[] outputItems;

    public override bool CanCraft(InventoryManager inv)
    {
        // Check each required component
        return requiredComponents.Select(req => inv.inventory.Any(slot => slot.data == req && slot.quantity > 0)).All(found => found);
    }

    public override void Craft(InventoryManager inv)
    {
        // Remove required components
        foreach (var req in requiredComponents)
            inv.RemoveObject(req);

        // Add output items
        foreach (var itm in outputItems)
            inv.AddObject(itm);

        Debug.Log($"[Craft] Crafted {recipeName}");
    }
}