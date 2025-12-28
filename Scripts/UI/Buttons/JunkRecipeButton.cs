using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JunkRecipeButton : MonoBehaviour
{
    [Header("UI References")]
    public Image icon;
    public TMP_Text title;
    public Button recycleButton;

    private JunkRecipeSO recipe;

    public void Initialize(JunkRecipeSO recipe)
    {
        this.recipe = recipe;

        Debug.Log($"[JunkRecipeButton] Initialize called on {name} with recipe: {recipe.recipeName}");

        icon.sprite = recipe.icon;
        title.text = recipe.recipeName;

        recycleButton.onClick.RemoveAllListeners();
        recycleButton.onClick.AddListener(OnRecyclePressed);

        RefreshInteractable();
    }

    public void RefreshInteractable()
    {
        bool canCraft = recipe.CanCraft(InventoryManager.Instance);
        recycleButton.interactable = canCraft;
        Debug.Log($"[JunkRecipeButton] RefreshInteractable for {recipe.recipeName} → {canCraft}");
    }

    private void OnRecyclePressed()
    {
        Debug.Log($"[JunkRecipeButton] OnRecyclePressed for {recipe.recipeName}");

        CraftingManager.Instance.TryCraft(recipe);

        // Refresh UI after crafting
        JunkStationUI.Instance.RefreshUI();
    }
}