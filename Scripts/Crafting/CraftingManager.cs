using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public static CraftingManager Instance;
    public InventoryManager inv;

    private void Awake()
    {
        Instance = this;
    }

    public void TryCraft(BaseRecipeSO recipe)
    {
        if (!recipe.CanCraft(inv))
        {
            Debug.Log("Missing required items/components!");
            return;
        }

        recipe.Craft(inv);
        inv.RefreshAllUI(); // update UI after changes
    }
}