using TMPro;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// A Object on Scene that can be interacted with
/// </summary>
public class InteractableObj : MonoBehaviour
{

    Collider2D coll;
    /// <summary>
    /// text that appears, when you hover over the object
    /// </summary>
    public string infoText;


    /// <summary>
    /// does the object gets in the inventory on click
    /// </summary>
    public bool pickableOnClick = false;
    /// <summary>
    /// The object in the inventory has a use while in inventory
    /// </summary>
    public bool KeepToUseInInventory = false;
    /// <summary>
    /// Event that will occur when the object is used while on inventory
    /// </summary>
    public UnityEvent eventsOnInventorySelect;

    /// <summary>
    /// the object does something on scene
    /// </summary>
    public bool EventTriggerOnClick = false;
    /// <summary>
    /// Event that will occur when the object is interacted while in scene
    /// </summary>
    public UnityEvent eventsOnClick;

    // Animator animator;


    void Start()
    {
        TryGetComponent<Collider2D>(out coll);

        // TryGetComponent<Animator>(out animator);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// When the mouse is clicked invokes the trigger and adds it to the inventory
    /// </summary>
    void OnMouseDown()
    {
        if (EventTriggerOnClick) eventsOnClick?.Invoke();

        if (pickableOnClick)
        {
            InventoryManager.AddToInventory(this.gameObject);

            gameObject.SetActive(false);
            //Destroy(gameObject); 
        }
    }
    void OnMouseOver()
    {
        DisplayInfo(true);
    }

    void OnMouseExit()
    {
        DisplayInfo(false);

    }

    void OnDisable()
    {
        DisplayInfo(false);

    }
    private void DisplayInfo(bool active)
    {
        if (infoText != "")
        {
            ItemInfoDisplayer displayer = FindAnyObjectByType<ItemInfoDisplayer>();
            if (displayer != null)
            {
                displayer.infoPanel.SetActive(active);

                // Vector3 mousePos = Camera.main.ViewportPointToRay(Input.mousePosition).origin;
                // Vector3 InfoTextPivotPos = new Vector3(0,0,0);

                // if (mousePos.x > 0.5) InfoTextPivotPos.x = 1.0f; else InfoTextPivotPos.x = 0f;
                // if (mousePos.y > 0.5) InfoTextPivotPos.y = 1.0f; else InfoTextPivotPos.y = 0f;

                // displayer.GetComponent<RectTransform>().pivot = InfoTextPivotPos;

            }
            if (active) displayer.GetComponentInChildren<TMP_Text>().text = infoText;

        }
    }

}

