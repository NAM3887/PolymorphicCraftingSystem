using UnityEngine;

public class JunkStation : WorldStation, IInteractable
{
    public string GetName() => stationName;

    public void Interact()
    {
        if (JunkStationUI.Instance.IsOpen)
            JunkStationUI.Instance.Close();
        else
            JunkStationUI.Instance.Open(this);
    }
}