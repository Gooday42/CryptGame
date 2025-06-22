using UnityEngine;
using UnityEngine.Events;

public class InventoryObject : MonoBehaviour
{
    [SerializeField] private string intName;
    [SerializeField] private string infoText;
    [SerializeField] private bool UseOnInventory;
    [SerializeField] private UnityEvent eventsOnInventorySelect;
    [SerializeField] private bool usable;
    [SerializeField] private GameObject SceneItem;
    bool FollowingTheMouse = false;

    public GameObject instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (infoText == "")
        {
            infoText = intName;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OutOfBag()
    {

        if (UseOnInventory)
        {
            eventsOnInventorySelect?.Invoke();
            //thisButton.interactable = false;
            if (instance == null && SceneItem != null)//Primera vez
            {
                instance = Instantiate(SceneItem);
                instance.SetActive(true);

                instance.GetComponent<Collider2D>().enabled = false;
                instance.GetComponent<SpriteRenderer>().enabled = false;
                instance.GetComponent<InteractableObj>().eventsOnInventorySelect?.Invoke();
                
                return;
            }

            

            instance.SetActive(!instance.activeSelf);
            if (instance.activeSelf) instance.GetComponent<InteractableObj>().eventsOnInventorySelect?.Invoke();


        }
        else
        {
            
            instance = Instantiate(SceneItem);
            instance.SetActive(true);
            instance.GetComponent<InteractableObj>().enabled = false;
            instance.GetComponent<Collider2D>().enabled = false;
            instance.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
            FollowingTheMouse = true;
        }

    }

    private void CheckInteractions()
    {
        FollowingTheMouse = false;
        //thisButton.interactable = true;
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
