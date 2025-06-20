using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// manager with the data of the inventory 
/// </summary>
public class InventoryManager : MonoBehaviour
{
    /// <summary>
    /// singleton of the inventory manager, not used
    /// </summary>
    public static InventoryManager Instance; // seems redundant https://discussions.unity.com/t/solved-do-static-variables-behave-reliable-on-scene-swap/826555/4

    //if all the inventory is going to be static, then it doesnt need to have a singleton, even the its not even been called, buet yeah even in 
    // scene changes the static values remain so it shouldnt be necessary to create a singleton or for the object to stay loaded


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
    /// creating the singleton for the inventory, not neccesary
    /// </summary>
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        print(OnInventoryChange);
    }

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
