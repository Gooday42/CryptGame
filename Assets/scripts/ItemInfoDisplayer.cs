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

            Vector3 mousePos = Camera.main.WorldToViewportPoint((Vector2)Input.mousePosition);
            Vector3 InfoTextPivotPos = Vector3.zero;

            InfoTextPivotPos.x = mousePos.x > 0.5 ? 1.0f : 0f;
            InfoTextPivotPos.y = mousePos.y > 0.5 ? 1.0f : 0f;
            infoPanel.GetComponent<RectTransform>().pivot = InfoTextPivotPos;
            infoPanel.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;

        }
    }
}
