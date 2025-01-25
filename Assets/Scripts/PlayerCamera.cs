using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private float leftBoundary, rightBoundary, leftTeleportPoint, rightTeleportPoint;
    [SerializeField] private RenderTexture renderTexture;
    [SerializeField] private GameObject stage, leftCapturePlane, rightCapturePlane;
    private Camera stageCaptureCamera;
    void Start()
    {
        leftBoundary = GameObject.Find("LeftBoundaryPoint").transform.position.x;
        rightBoundary = GameObject.Find("RightBoundaryPoint").transform.position.x;
        leftTeleportPoint = GameObject.Find("LeftTeleportPoint").transform.position.x;
        rightTeleportPoint = GameObject.Find("RightTeleportPoint").transform.position.x;

        // Setup the stage render camera
        stageCaptureCamera = new GameObject("StageCaptureCamera").AddComponent<Camera>();
        stageCaptureCamera.transform.position = new Vector3(0, 0, -10);
        stageCaptureCamera.targetTexture = renderTexture;
        stageCaptureCamera.orthographic = true;

        Bounds stageBounds = stage.GetComponent<Renderer>().bounds;

        // Convert bounds corners to viewport space
        Vector3 minViewport = Camera.main.WorldToViewportPoint(stageBounds.min);
        Vector3 maxViewport = Camera.main.WorldToViewportPoint(stageBounds.max);
        
        // Calculate rect values (clamped to 0-1 range)
        float x = Mathf.Clamp01(minViewport.x);
        float y = Mathf.Clamp01(minViewport.y);
        float width = Mathf.Clamp01(maxViewport.x - minViewport.x);
        float height = Mathf.Clamp01(maxViewport.y - minViewport.y);

        // Apply to camera
        stageCaptureCamera.rect = new Rect(x, y, width, height);
        stageCaptureCamera.orthographicSize = stageBounds.extents.y;
    }

    void Update()
    {        
        // If the player is outside the boundary, teleport them to the other side of the map
        if (transform.position.x < leftBoundary)
        {
            transform.position = new Vector3(rightTeleportPoint, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightBoundary)
        {
            transform.position = new Vector3(leftTeleportPoint, transform.position.y, transform.position.z);
        }
    }
}
