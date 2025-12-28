using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class CraftingStationUI : MonoBehaviour
{
    public static CraftingStationUI Instance;

    [Header("UI")]
    public GameObject uiRoot;              
    public Transform recipeListParent;     
    public GameObject recipeButtonPrefab;  
    
    [Header("Debug")]
    public bool IsOpen = false;

    private CraftingStation _currentStation;

    private void Awake()
    {
        Instance = this;
        uiRoot.SetActive(false);
    }

    // Called by CraftingStation.Interact()
    public void Open(CraftingStation station)
    {       
        if (!IsOpen && UIManager.IsAnyUIOpen) return;

        UIManager.IsAnyUIOpen = true;
        UIManager.Instance.HidePrompt();
        
        _currentStation = station;
        IsOpen = true;
        uiRoot.SetActive(true);

        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        RefreshUI();
    }

    public void Close()
    {
        UIManager.IsAnyUIOpen = false;
        
        IsOpen = false;
        uiRoot.SetActive(false);

        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Refreshes recipe list based on inventory
    public void RefreshUI()
    {
        // Clear old buttons
        foreach (Transform child in recipeListParent)
            Destroy(child.gameObject);

        // Get crafting recipes only
        List<CraftingRecipeSO> craftingRecipes =
            RecipeDatabase.Instance.GetCraftingRecipes().OfType<CraftingRecipeSO>().ToList();

        foreach (var recipe in craftingRecipes)
        {
            // TODO ADD BUTTON OR UI
            GameObject obj = Instantiate(recipeButtonPrefab, recipeListParent);
            var btn = obj.GetComponent<CraftingRecipeButton>();
            btn.Initialize(recipe);
        }
    }
}