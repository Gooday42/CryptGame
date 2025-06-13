using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    Button thisButton;
    bool FollowingTheMouse = false;
    private GameObject instance;

    public GameObject thisItem;

    void Start()
    {
        TryGetComponent<Button>(out thisButton);

        thisButton.onClick.AddListener(() => TryToUse());   
    }
    public void TryToUse()
    {

        if (InventoryManager.usingAnItem && instance != null)
        {
            if (!instance.activeSelf) return;
            instance.SetActive(!instance.activeSelf);
            InventoryManager.usingAnItem = false;
            return;

        }

        if (!InventoryManager.usingAnItem && thisItem != null)
        {
            InventoryManager.usingAnItem = true;

            if (thisItem.GetComponent<InteractableObj>().KeepToUseInInventory)
            {
                //thisButton.interactable = false;
                if (instance == null)//Primera vez
                {
                    instance = Instantiate(thisItem);
                    instance.SetActive(true);

                    instance.GetComponent<Collider2D>().enabled = false;
                    instance.GetComponent<SpriteRenderer>().enabled = false;
                    instance.GetComponent<InteractableObj>().eventsOnInventorySelect?.Invoke();
                    return;
                }

                instance.SetActive(true);
                if (instance.activeSelf) instance.GetComponent<InteractableObj>().eventsOnInventorySelect?.Invoke();

            }
            else
            {
                thisButton.interactable = false;
                instance = Instantiate(thisItem);
                instance.SetActive(true);
                instance.GetComponent<InteractableObj>().enabled = false;
                instance.GetComponent<Collider2D>().enabled = false;
                instance.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
                FollowingTheMouse = true;
            }
        }

    }
    private void CheckInteractions()
    {   
        FollowingTheMouse = false;
        thisButton.interactable = true;
        InventoryManager.usingAnItem = false;
        Destroy(instance);
    }
    private void FixedUpdate()
    {
        if (FollowingTheMouse)
        {
            instance.transform.position = (Vector2)Camera.main.ScreenPointToRay(Input.mousePosition).origin;

            if (Input.GetMouseButtonDown(0))
            {
               CheckInteractions();
            }
        }
    }


}
