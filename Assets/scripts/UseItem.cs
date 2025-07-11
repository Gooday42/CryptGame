using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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

        if (InventoryManager.usingAnItem != null && instance != null)
        {
            if (!instance.activeSelf) return;
            instance.SetActive(!instance.activeSelf);
            InventoryManager.usingAnItem = null;
            return;

        }

        if (InventoryManager.usingAnItem == null && thisItem != null)
        {
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
                    InventoryManager.usingAnItem = instance;

                    return;
                }

                instance.SetActive(true);
                if (instance.activeSelf)
                {
                    instance.GetComponent<InteractableObj>().eventsOnInventorySelect?.Invoke();
                }
            }
            else
            {
                thisButton.interactable = false;
                instance = Instantiate(thisItem);
                instance.SetActive(true);
                instance.GetComponent<InteractableObj>().CanShowInfo = false;
                instance.GetComponent<Collider2D>().isTrigger = false;
                instance.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.9f);
                FollowingTheMouse = true;

                InventoryManager.usingAnItem = instance;

            }
        }

    }
    private void CheckInteractions()
    {
        FollowingTheMouse = false;
        thisButton.interactable = true;
        InventoryManager.usingAnItem = null;
    }
    private void FixedUpdate()
    {
        if (FollowingTheMouse)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(WaitUntilAllInteractionCheck());
                thisButton.interactable = true;

            }

            if(InventoryManager.usingAnItem != null) instance.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;

        }
    }

    IEnumerator WaitUntilAllInteractionCheck()
    {
        yield return new WaitForSeconds(0.1f);
        InventoryManager.usingAnItem = null;
        Destroy(instance);
    }
}   
