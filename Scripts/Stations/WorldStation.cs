using UnityEngine;

public abstract class WorldStation : MonoBehaviour
{ 
    [Header("Station Settings")]
    public string stationName = "Station";
    public virtual string GetStationName() { return  stationName; }
}

