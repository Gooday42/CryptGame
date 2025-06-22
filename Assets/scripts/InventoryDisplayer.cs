using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// manager for the visual part of the inventory
/// </summary>
public class InventoryDisplayer : MonoBehaviour
{
    /// <summary>
    /// Adds the Visual Update when the inventory change
    /// </summary>
    private void Start() {
        InventoryManager.OnInventoryChange += updateDisplay;

    }

    /// <summary>
    /// Updates each space of the inventory visually with the item it have
    /// </summary>
    public void updateDisplay()
    {
        int i = 0;
        foreach (GameObject item in InventoryManager.GetInventory())
        {
            transform.GetChild(i).GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            transform.GetChild(i).GetComponent<Inventariobject>().thisItem = item;
            
            i++;
        }
    }

}
