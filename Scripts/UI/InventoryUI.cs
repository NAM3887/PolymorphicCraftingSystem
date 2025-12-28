using UnityEngine;
using UnityEngine.InputSystem;

// Controls Inventory UI open/close and population
public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryMenu;
    private bool isOpen = false;

    public void ToggleInventory(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!isOpen && UIManager.IsAnyUIOpen) return;
        
        isOpen = !isOpen;
        InventoryManager.Instance.InventoryUIOpen = isOpen;
        
        inventoryMenu.SetActive(isOpen);

        if (isOpen)
        {
            UIManager.IsAnyUIOpen = true;
            UIManager.Instance.HidePrompt();
            
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            StartCoroutine(RefreshNextFrame());
        }
        else
        {
            UIManager.IsAnyUIOpen = false;
            
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private System.Collections.IEnumerator RefreshNextFrame()
    {
        yield return null;
        InventoryManager.Instance.RefreshAllUI();
    }
}