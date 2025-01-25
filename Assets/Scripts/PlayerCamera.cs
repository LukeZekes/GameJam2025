using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Camera _camera;
    private float leftBoundary;
    private float rightBoundary;

    void Start()
    {
        _camera = Camera.main;
        leftBoundary = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightBoundary = _camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }

    void Update()
    {        
        // If the player is outside the boundary, teleport them to the other side of the map
        if (transform.position.x < leftBoundary)
        {
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightBoundary)
        {
            transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);
        }
    }
}
