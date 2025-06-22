using UnityEngine;
using UnityEngine.Events;

public class InventoryObject : MonoBehaviour
{
    [SerializeField] private string intName;
    [SerializeField] private string infoText;
    [SerializeField] private bool UseOnInventory;
    [SerializeField] private UnityEvent eventsOnInventorySelect;
    [SerializeField] private bool usable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
