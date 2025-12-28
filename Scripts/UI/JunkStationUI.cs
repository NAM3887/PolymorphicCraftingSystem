using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class JunkStationUI : MonoBehaviour
{
    public static JunkStationUI Instance;

    [Header("UI")]
    public GameObject uiRoot;               // panel root
    public Transform recipeListParent;      // content transform
    public GameObject recipeButtonPrefab;   // prefab for recipe entry

    public bool IsOpen = false;

    private JunkStation _currentStation;

    private void Awake()
    {
        Instance = this;
        uiRoot.SetActive(false);
    }

    public void Open(JunkStation station)
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

    public void RefreshUI()
    {
        // Clear old entries
        foreach (Transform child in recipeListParent)
            Destroy(child.gameObject);

        // Get ONLY junk recipes
        var junkRecipes = RecipeDatabase.Instance.allRecipes
            .OfType<JunkRecipeSO>()
            .ToList();

        // Build UI entries
        foreach (var recipe in junkRecipes)
        {
            var buttonObj = Instantiate(recipeButtonPrefab, recipeListParent);
            var btn = buttonObj.GetComponent<JunkRecipeButton>();

            if (btn == null)
                Debug.LogError("JunkRecipeButton script missing on prefab!");

            btn.Initialize(recipe); 
        }
    }
}