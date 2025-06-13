using UnityEngine;
using UnityEngine.UI;

public class ItemInfoDisplayer : MonoBehaviour
{
    public GameObject infoPanel;
    void Start()
    {
        infoPanel.SetActive(false);
    }

    void Update()
    {
        if (infoPanel.activeSelf)
        {

                Vector3 mousePos = Camera.main.WorldToViewportPoint((Vector2) Input.mousePosition);
                Vector3 InfoTextPivotPos = new Vector3(0,0,0);

                if (mousePos.x > 0.5) InfoTextPivotPos.x = 1.0f; else InfoTextPivotPos.x = 0f;
                if (mousePos.y > 0.5) InfoTextPivotPos.y = 1.0f; else InfoTextPivotPos.y = 0f;

                infoPanel.GetComponent<RectTransform>().pivot = InfoTextPivotPos;
            infoPanel.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;

        }
    }
}
