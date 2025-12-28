using UnityEngine;

// Instance of an item that exists in the world
// Contains Item data
public class WorldItem : MonoBehaviour, IInteractable
{
    [SerializeField] private Item itemData;
    public Item ItemData => itemData;

    public string GetName() => itemData.DisplayName;

    public void Interact()
    {
        Debug.Log("WorldItem.Interact START");

        Debug.Log("ItemData = " + itemData);
        Debug.Log("InventoryManager.Instance = " + InventoryManager.Instance);

        // polymorphic
        if (!UIManager.IsAnyUIOpen)
        {
            InventoryManager.Instance.AddObject(itemData);

            Debug.Log("DESTROY ITEM");
            Destroy(gameObject);
        }
    }
}