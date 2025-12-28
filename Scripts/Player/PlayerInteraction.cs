using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private float interactRange = 3f;

    private Transform cam;
    private IInteractable currentInteractable;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        InteractableRaycast();
    }

    private void InteractableRaycast()
    {
        //Debug.Log("InteractableRaycast");
        RaycastHit hit;

        // Reset if nothing hit
        currentInteractable = null;
        UIManager.Instance.HidePrompt();

        // Raycast forward from camera
        if (Physics.Raycast(cam.position, cam.forward, out hit, interactRange))
        {
            //Debug.Log("Raycast hit: " + hit.collider.name);
            // Try to find an interactable interface in the object that was hit by the raycast
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
            if (interactable != null)
            {
                //Debug.Log("Interactable detected: " + interactable.GetName());
                currentInteractable = interactable;
                UIManager.Instance.ShowPrompt(interactable.GetName());
                
            }
        }
    }

    // Call interact on the current interactable object
    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        currentInteractable?.Interact();
    }
}