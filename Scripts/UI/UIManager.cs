using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Singleton
    public static UIManager Instance;
    public static bool IsAnyUIOpen = false;

    private void Awake() => Instance = this;

    [SerializeField] private GameObject popupPanel;
    [SerializeField] private TMP_Text popupText;

    // Called by PlayerInteraction
    public void ShowPrompt(string name)
    {
        popupText.text = $"Press F to interact {name}";
        popupPanel.SetActive(true);
    }

    public void HidePrompt()
    {
       
        popupPanel.SetActive(false);
    }
}