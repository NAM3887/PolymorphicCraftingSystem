using UnityEngine;

[CreateAssetMenu(fileName = "CraftingComponent", menuName = "Scriptable Objects/CraftingComponent")]
public class CraftingComponent : ScriptableObject, IInventoryObject
{
    // used for display
    public string componentName;
    public Sprite componentSprite;
    
    // Used for recipe search 
    public ComponentType componentType;
    
    // Getters for IInventoryObject
    public bool CanStack => true;
    public int MaxStack => 99;
    
    // Getters for IDisplayable
    public string DisplayName => componentName;
    public Sprite DisplaySprite => componentSprite;
}

public enum ComponentType
{
    Metal,
    Wood,
    Gears,
    Glass,
    Spring
};
