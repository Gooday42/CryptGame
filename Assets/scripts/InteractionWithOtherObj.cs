using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Events;

public class InteractionWithOtherObj : MonoBehaviour
{
    [SerializedDictionary("Name", "Event")]
    public SerializedDictionary<string, UnityEvent> EventsTriggerByName;

    void FixedUpdate()
    {
        if (InventoryManager.usingAnItem && InventoryManager.CheckIfInInventory(gameObject))
        {
            
        }
    }
}
