using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// manager with the data of the inventory 
/// </summary>
public class InventoryManager : MonoBehaviour
{
    

    /// <summary>
    /// List of Objects inside the inventrory of the player
    /// </summary>
    private static List<GameObject> Inventory = new();
    /// <summary>
    /// Action made when something gets in out or updated in the inventory
    /// </summary>
    public static event Action OnInventoryChange;
    /// <summary>
    /// A indicator for the time a item is being used
    /// </summary>
    public static bool usingAnItem = false;

    

    /// <summary>
    /// Adds a item to the inventory
    /// </summary>
    /// <param name="toAdd"> the item in the inventory that its going to be used</param>
    public static void AddToInventory(GameObject toAdd)
    {
        Inventory.Add(toAdd);
        print(toAdd.name);
        OnInventoryChange?.Invoke();
    }

    /// <summary>
    /// Check if a item is in the inventory
    /// </summary>
    /// <param name="checkThis"> item to check if is in </param>
    /// <returns> true if the exact object is in the inventory</returns>
    public static bool CheckIfInInventory(GameObject checkThis)
    {
        return Inventory.Contains(checkThis);
    }

    /// <summary>
    /// Get the inventory
    /// </summary>
    /// <returns>the list of items in the inventory</returns>

    public static List<GameObject> GetInventory()
    {
        return Inventory;
    }
}
