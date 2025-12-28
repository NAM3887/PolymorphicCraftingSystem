using UnityEngine;

// Interface for objects that can be displayed on the ui (items and crafting components)
public interface IDisplayable
{
      string DisplayName { get; }
      Sprite DisplaySprite { get; }
}
