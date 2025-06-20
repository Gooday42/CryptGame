using UnityEngine;
using AYellowpaper.SerializedCollections;
using System;

public class MouseManager : MonoBehaviour
{
    /// <summary>
    /// singleton for the manager
    /// </summary>
    public static MouseManager Instance;


    /// <summary>
    /// Layerfor detectable objects
    /// </summary>
    [Header("Settings")]
    
    [SerializeField] private LayerMask interactableLayers;  // Layers to detect


    /// <summary>
    /// icons to use when the mouse is updated
    /// </summary>
    [Header("Action Icons")]
    [SerializedDictionary("Action Tag", "Icon")]
    [SerializeField] private SerializedDictionary<string, Sprite> actionIcons;


    /// <summary>
    /// Event to notify when cursor icon changes
    /// </summary>
    public event Action<Sprite> OnCursorIconChange;
    /// <summary>
    /// Currently displayed icon
    /// </summary>
    private Sprite currentIcon;
    /// <summary>
    /// maincamera of the scene
    /// </summary>
    private Camera mainCamera;

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
    }

    /// <summary>
    /// setting for the icons and the camera
    /// </summary>

    void Start()
    {
        mainCamera = Camera.main;
        currentIcon = null;
    }

    

    void Update()
    {
        UpdateMouseRay();
        CheckObjectUnderMouse();
    }

    /// <summary>
    /// Create ray for debugging/other uses
    /// </summary>

    private void UpdateMouseRay()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        whatIsOverMouse = new Ray2D(mousePosition, Vector2.zero);
    }

    /// <summary>
    /// 
    /// </summary>

    private void CheckObjectUnderMouse()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePos, interactableLayers);

        Sprite newIcon = null;

        if (hit != null)
        {
            // Check if object's tag has an associated icon
            if (actionIcons.TryGetValue(hit.tag, out Sprite icon))
            {
                newIcon = icon;
            }
        }

        // Only update if icon state changed
        if (newIcon != currentIcon)
        {
            currentIcon = newIcon;
            OnCursorIconChange?.Invoke(currentIcon);
        }
    }

    // Public access to mouse ray
    public Ray2D whatIsOverMouse { get; private set; }
}