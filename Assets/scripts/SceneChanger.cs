using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public GameObject scene;

    void OnMouseDown()
    {
        if (!scene) return;

        Camera.main.gameObject.transform.position = new Vector3(0, 0, -10);
        SceneManager.ChangeBackground(scene);
        scene.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
