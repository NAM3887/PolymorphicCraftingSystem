POLYMORPHIC CRAFTING SYSTEM
=======================================

 CORE CONCEPT
---------------
The inventory system uses polymorphism so that different kinds of game
objects (Items, Crafting Components, Recipes, etc.) can be handled
through a single unified interface. This makes UI, storage, and logic clean and scalable.


 BASE INTERFACE: IDISPLAYABLE
-------------------------------
IDisplayable represents ANY object that can appear in the UI.

It guarantees:
- A display name
- An icon (sprite)

Examples that implement it:
- Items
- Crafting Components
- Recipes
- Crafting outputs

UI slot only cares about IDisplayable, so it can show ANY of these.


 INVENTORY INTERFACE: IINVENTORYOBJECT
----------------------------------------
IInventoryObject extends IDisplayable.

It represents anything that can be stored in the inventory.

It guarantees:
- CanStack: whether the object can stack
- MaxStack: maximum quantity that can stack
- DisplayName / DisplayIcon (inherited)

Examples that implement it:
- Items
- Crafting Components

With this implementation, NOT every displayable object is an inventory object.
This allows the inventory system to store only valid inventory items,
while the UI can still display ANY of them.


 INVENTORY SLOT DATA
----------------------
InventorySlot stores:
- A reference to an IInventoryObject
- A quantity (for stacking)

InventoryManager stores: List<InventorySlot>

This enables stacking, merging, and removal using the same logic.


 UNIFIED UI SLOT
-------------------
UISlot does not care whether it is handling an Item, Component,
Recipe, or anything else.

It only requires IDisplayable:
- SetData(IDisplayable data, quantity)
- Shows name and icon
- Displays "xQuantity" automatically

This removes all duplicated UI scripts.


 INVENTORY MANAGER
--------------------
InventoryManager handles:
- Adding inventory objects (with stacking logic)
- Removing inventory objects
- Refreshing the UI
- Instantiating UI slots

It operates purely on IInventoryObject, not on concrete classes. So its able to be reused with the UISlot to display Items and CraftingComponents


 POLYMORPHISM
---------------------------
- One item UI system for everything
- No duplicate code for items vs components
- Recipes can use UI without being inventory items
- Scalable for future systems 
- Fewer scripts, smaller codebase, easier maintenance

This system allows new object types to be added with almost no rework to existing code.

-------
IDisplayable = “This can appear in the UI”
IInventoryObject = “This is a displayable object that can be stored in inventory”


