using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingRecipeButton : MonoBehaviour
{
    [Header("UI References")]
    public Image icon;
    public TMP_Text title;
    public Button craftButton;

    private CraftingRecipeSO recipe;

    public void Initialize(CraftingRecipeSO recipe)
    {
        this.recipe = recipe;

        icon.sprite = recipe.icon;
        title.text = recipe.recipeName;

        // Prevent stacking listeners
        craftButton.onClick.RemoveAllListeners();
        craftButton.onClick.AddListener(OnClick);

        RefreshInteractable();
    }

    public void RefreshInteractable()
    {
        craftButton.interactable = recipe.CanCraft(InventoryManager.Instance);
    }

    private void OnClick()
    {
        CraftingManager.Instance.TryCraft(recipe);

        // Update UI after crafting
        CraftingStationUI.Instance.RefreshUI();
    }
}