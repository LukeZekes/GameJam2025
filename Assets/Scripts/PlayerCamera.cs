using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Camera _camera;
    public float leftBoundary;
    public float rightBoundary;

    void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }
    void Start()
    {
        _camera.transform.position = new Vector3(0, 0, -10);
        leftBoundary = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightBoundary = _camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float moveSpeed = 5f;
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
        
        
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
