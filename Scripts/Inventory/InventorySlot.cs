using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Stores object + Quantity
[System.Serializable]
public class InventorySlot
{
    public IInventoryObject data;
    public int quantity;

    public InventorySlot(IInventoryObject data, int quantity)
    {
        this.data = data;
        this.quantity = quantity;
    }
}
