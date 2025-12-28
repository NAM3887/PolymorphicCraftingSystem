using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISlot : MonoBehaviour 
{
    public TMP_Text nameText;
    public Image iconImage;
    
    private IDisplayable displayableObject;

    public void SetData(IDisplayable displayableObjectdata, int quantity = -1)
    {
        displayableObject = displayableObjectdata;

        if (quantity > 0)
        {
           nameText.text = $"{displayableObjectdata.DisplayName} x{quantity}"; 
        }
        else
        {
            nameText.text = displayableObjectdata.DisplayName;
        }
        iconImage.sprite = displayableObject.DisplaySprite;
    }
    public IDisplayable GetDisplayableObject() { return displayableObject; }
}

