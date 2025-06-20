using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;
    [SerializeField]
    public GameObject Background;
    public static GameObject background;
    private static GameObject thisCamera;
    private static Camera cam;
    private static SpriteRenderer bgRenderer;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        thisCamera = Camera.main.gameObject;
        cam = thisCamera.GetComponent<Camera>();
        background = Background;
    }

    void Start()
    {
        if (Background != null) ChangeBackground(Background);
    }

    public static bool checkRightIfInsideCam()
    {
        // Return true if background or renderer is missing (no borders to check)
        if (background == null || bgRenderer == null || cam == null)
            return false;

        Bounds bgBounds = bgRenderer.bounds;
        //float leftCamBorder = cam.ViewportToWorldPoint(new Vector3(0, 0.5f)).x;
        float rightCamBorder = cam.ViewportToWorldPoint(new Vector3(1, 0.5f, cam.nearClipPlane)).x;
        //print(leftCamBorder + "," + rightCamBorder);

        if (bgBounds.max.x > rightCamBorder) return true;

        return false;

    }
    public static bool checkIfLeftInsideCam()
    {
        // Return true if background or renderer is missing (no borders to check)
        if (background == null || bgRenderer == null || cam == null)
            return false;

        Bounds bgBounds = bgRenderer.bounds;
        float leftCamBorder = cam.ViewportToWorldPoint(new Vector3(0, 0f, cam.nearClipPlane)).x;

        if (bgBounds.min.x < leftCamBorder) return true;

        return false;
    }

    public static bool CheckIfImageIsInside()
    {
        Bounds bgBounds = bgRenderer.bounds;
        if (bgBounds.max.x < cam.ViewportToWorldPoint(new Vector3(1f, 1f, cam.nearClipPlane)).x
            && bgBounds.min.x < cam.ViewportToWorldPoint(new Vector3(0f, 0f, cam.nearClipPlane)).x)
        {
            return true;
        }
        return false;
    }
    public static void ChangeBackground(GameObject bg)
    {
        background = bg;

        bgRenderer = bg.GetComponent<SpriteRenderer>();
    }

    public static void MoveCameraToleft()
    {

        if (checkIfLeftInsideCam()) thisCamera.transform.position += Vector3.left;
    }

    public static void MoveCameraToRight()
    {
        if (checkRightIfInsideCam()) thisCamera.transform.position += Vector3.right;

    }


}


