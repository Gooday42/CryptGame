using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplayer : MonoBehaviour
{
    private void Start() {
        InventoryManager.OnInventoryChange += updateDisplay;

    }
    public void updateDisplay()
    {
        int i = 0;
        foreach (GameObject item in InventoryManager.GetInventory())
        {
            transform.GetChild(i).GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            transform.GetChild(i).GetComponent<UseItem>().thisItem = item;
            
            i++;
        }
    }

}
