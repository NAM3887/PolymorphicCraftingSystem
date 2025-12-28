using UnityEngine;
using System.Collections.Generic;
using System.Linq;

// Handles Junking logic
[CreateAssetMenu(fileName = "JunkRecipe", menuName = "Scriptable Objects/Junk Recipe")]
public class JunkRecipeSO : BaseRecipeSO
{
    public Item requiredItem;
    public List<CraftingComponent> outputComponents;

    public override bool CanCraft(InventoryManager inv)
    {
        // Check if any slot matches the required item
        return inv.inventory.Any(slot => slot.data == requiredItem && slot.quantity > 0);
    }

    public override void Craft(InventoryManager inventory)
    {
        // Remove the required item
        inventory.RemoveObject(requiredItem);

        // Add all resulting components
        foreach (var comp in outputComponents)
            inventory.AddObject(comp);

        Debug.Log($"[Scrap] Converted {requiredItem.name} → components");
    }
}