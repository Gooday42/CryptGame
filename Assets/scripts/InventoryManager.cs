using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private static List<GameObject> Inventory = new();
    public static event Action OnInventoryChange;
    public static bool usingAnItem = false;
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

    public static void AddToInventory(GameObject toAdd)
    {
        Inventory.Add(toAdd);
        print(toAdd.name);
        OnInventoryChange?.Invoke();
    }
    public static bool CheckIfInInventory(GameObject checkThis)
    {
        return Inventory.Contains(checkThis);
    }

    public static List<GameObject> GetInventory()
    {
        return Inventory;
    }
}
