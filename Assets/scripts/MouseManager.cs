using UnityEngine;
using AYellowpaper.SerializedCollections;
using System;

public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance;
    
    [Header("Settings")]
    [SerializeField] private LayerMask interactableLayers;  // Layers to detect
    
    [Header("Action Icons")]
    [SerializedDictionary("Action Tag", "Icon")]
    [SerializeField] private SerializedDictionary<string, Sprite> actionIcons;

    // Event to notify when cursor icon changes
    public event Action<Sprite> OnCursorIconChange;

    private Sprite currentIcon;  // Currently displayed icon
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

    private void UpdateMouseRay()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        // Create ray for debugging/other uses
        whatIsOverMouse = new Ray2D(mousePosition, Vector2.zero);
    }

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