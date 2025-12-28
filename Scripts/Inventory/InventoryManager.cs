using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("UI Parents")]
    public Transform itemSlotParent;         // ScrollRect #1 (Items)
    public Transform componentSlotParent;    // ScrollRect #2 (Components)

    [Header("Slot Prefab")]
    public GameObject slotPrefab;

    // Internal UI tracking
    private List<GameObject> spawnedItemSlots = new List<GameObject>();
    private List<GameObject> spawnedComponentSlots = new List<GameObject>();

    // Unified polymorphic inventory
    public List<InventorySlot> inventory = new List<InventorySlot>();

    [HideInInspector]
    public bool InventoryUIOpen = false;

    private void Awake()
    {
        Instance = this;
    }

    // ---------------------------------------------------------
    // ADD TO INVENTORY 
    // ---------------------------------------------------------
    public void AddObject(IInventoryObject obj)
    {
        if (obj.CanStack)
        {
            var slot = inventory.Find(s => s.data == obj);
            if (slot != null && slot.quantity < obj.MaxStack)
            {
                slot.quantity++;
                RefreshAllUI();
                return;
            }
        }

        inventory.Add(new InventorySlot(obj, 1));
        RefreshAllUI();
    }

    // ---------------------------------------------------------
    // REMOVE FROM INVENTORY
    // ---------------------------------------------------------
    public void RemoveObject(IInventoryObject obj)
    {
        var slot = inventory.Find(s => s.data == obj);
        if (slot == null) return;
        
        slot.quantity--;
        
        if (slot.quantity <= 0)
            inventory.Remove(slot);
        RefreshAllUI();
    }

    // ---------------------------------------------------------
    // REFRESH ALL UI LISTS
    // ---------------------------------------------------------
    public void RefreshAllUI()
    {
        if (!InventoryUIOpen) return;

        RefreshItemUI();
        RefreshComponentUI();
    }

    // ---------------------------------------------------------
    // REFRESH ITEMS ONLY (ScrollRect #1)
    // ---------------------------------------------------------
    public void RefreshItemUI()
    {
        ClearUI(spawnedItemSlots);

        foreach (var slot in inventory.Where(slot => slot.data is Item))
        {
            CreateUISlot(slot, itemSlotParent, spawnedItemSlots);
        }
    }

    // ---------------------------------------------------------
    // REFRESH COMPONENTS ONLY (ScrollRect #2)
    // ---------------------------------------------------------
    private void RefreshComponentUI()
    {
        ClearUI(spawnedComponentSlots);

        foreach (var slot in inventory.Where(slot => slot.data is CraftingComponent))
        {
            CreateUISlot(slot, componentSlotParent, spawnedComponentSlots);
        }
    }

    // ---------------------------------------------------------
    // CREATE A UI SLOT
    // ---------------------------------------------------------
    private void CreateUISlot(InventorySlot invSlot, Transform parent, List<GameObject> list)
    {
        var obj = Instantiate(slotPrefab, parent);
        var uiSlot = obj.GetComponent<UISlot>();
        uiSlot.SetData(invSlot.data, invSlot.quantity);
        list.Add(obj);
    }

    // ---------------------------------------------------------
    // CLEAR A UI LIST
    // ---------------------------------------------------------
    private static void ClearUI(List<GameObject> list)
    {
        foreach (var obj in list)
            Destroy(obj);
        list.Clear();
    }
}
