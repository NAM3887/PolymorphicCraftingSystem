// This class will allow the ability to create new utems in the editor

using System;
using System.Collections.Generic;
using UnityEngine;

// Items is a IInventory Object
[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item", order = 1)]
public class Item : ScriptableObject, IInventoryObject
{
    public string itemName;
    public Sprite icon;
    
    public bool stackable = true;
    public int maxStack = 99;
    
    // Getters for IDisplayable
    public string DisplayName => itemName;
    public Sprite DisplaySprite => icon;
    
    // Getters for IInventoryObject
    public bool CanStack => stackable;
    public int MaxStack => maxStack;
}

