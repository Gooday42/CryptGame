using UnityEngine;

public class fullout : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Input.GetMouseButtonDown(i))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        
    }
}
