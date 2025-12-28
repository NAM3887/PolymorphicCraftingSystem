using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [Header("References")]
    public Transform playerBody;
    
    [Header("Settings")]
    public float sensitivity = .2f;
    public float smoothTime = 0.02f;

    private float xRotation = 0f;
    private Vector2 rawLookInput;
    private Vector2 smoothLook;
    private Vector2 smoothVelocity;
    

    public void OnLook(InputAction.CallbackContext context)
    {
        if (UIManager.IsAnyUIOpen)
        {
            rawLookInput = Vector2.zero;   // Stop input when UI is open
            return;
        }

        rawLookInput = context.ReadValue<Vector2>() * sensitivity;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (UIManager.IsAnyUIOpen)
            return;   // stop ALL rotation

        // Smooth mouse movement (this uses fixed smoothtime, not delta)
        smoothLook.x = Mathf.SmoothDamp(
            smoothLook.x, rawLookInput.x,
            ref smoothVelocity.x, smoothTime);

        smoothLook.y = Mathf.SmoothDamp(
            smoothLook.y, rawLookInput.y,
            ref smoothVelocity.y, smoothTime);

        // Apply vertical rotation
        xRotation -= smoothLook.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Apply horizontal rotation
        playerBody.Rotate(Vector3.up * smoothLook.x);
    }
}