using UnityEngine;

public class CraftingStation : WorldStation, IInteractable
{
    public string GetName() => stationName;

    public void Interact()
    {
        if (CraftingStationUI.Instance.IsOpen)
            CraftingStationUI.Instance.Close();
        else
            CraftingStationUI.Instance.Open(this);
    }
}