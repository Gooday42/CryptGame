using NUnit.Framework;
using System;
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
        try
        {
            InventoryObject item = GetComponentInChildren<InventoryObject>();
            print("founded");
            if (item.instance != null)
            {
                print("ersdf");
                return;
            }
            if (InventoryManager.usingAnItem)
            {
                //merging or clues or nothing
                item.instance.SetActive(!instance.activeSelf);
                InventoryManager.usingAnItem = false;
            }
            else
            {
                InventoryManager.usingAnItem = true;
                item.OutOfBag();

            }
            //.TryToUse();
        }
        catch (Exception e)
        {
            print(e.Message);
        }

        

    }
    //private void CheckInteractions()
    //{
    //    FollowingTheMouse = false;
    //    thisButton.interactable = true;
    //    InventoryManager.usingAnItem = false;
    //    Destroy(instance);
    //}
    //private void FixedUpdate()
    //{
    //    if (FollowingTheMouse)
    //    {
    //        instance.transform.position = (Vector2)Camera.main.ScreenPointToRay(Input.mousePosition).origin;

    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            CheckInteractions();
    //        }
    //    }
    //}


}
