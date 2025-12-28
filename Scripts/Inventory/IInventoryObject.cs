using System;
using UnityEngine;

public interface IInventoryObject : IDisplayable
{ 
    bool CanStack { get; } 
    int MaxStack { get; }
    
}
