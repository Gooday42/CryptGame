using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObj : MonoBehaviour
{
    Collider2D coll;
    public string infoText;

    public bool pickableOnClick = false;
    public bool KeepToUseInInventory = false;
    public UnityEvent eventsOnInventorySelect ;
    public bool EventTriggerOnClick = false;
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

    void OnMouseDown()
    {
        if(EventTriggerOnClick)eventsOnClick?.Invoke();

        if (pickableOnClick)
        {
            InventoryManager.AddToInventory(this.gameObject);
            gameObject.SetActive(false);
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
            if(active) displayer.GetComponentInChildren<TMP_Text>().text = infoText;

        }
    }

}

