using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private float leftBoundary, rightBoundary, leftTeleportPoint, rightTeleportPoint;
    [SerializeField] private GameObject stage, leftCapturePlane, rightCapturePlane;
    void Start()
    {
        leftBoundary = GameObject.Find("LeftBoundaryPoint").transform.position.x;
        rightBoundary = GameObject.Find("RightBoundaryPoint").transform.position.x;
        leftTeleportPoint = GameObject.Find("LeftTeleportPoint").transform.position.x;
        rightTeleportPoint = GameObject.Find("RightTeleportPoint").transform.position.x;

        // Reuse this if we need a new camera after resizing the play area
        // Setup the stage render camera - duplicates the background, bubbles, enemies
        // stageCaptureCamera = new GameObject("StageCaptureCamera").AddComponent<Camera>();
        // stageCaptureCamera.transform.position = new Vector3(0, 0, -10);
        // stageCaptureCamera.targetTexture = stageRenderTexture;
        // stageCaptureCamera.orthographic = true;

        // Bounds stageBounds = stage.GetComponent<Renderer>().bounds;

        // Apply to camera
        // stageCaptureCamera.rect = new Rect(0, 0, 1, 1);
        // stageCaptureCamera.orthographicSize = stageBounds.size.y;

        // Setup the player camera - follows the player and captures everything except the UI
        int resWidth = Screen.width;
        int resHeight = Screen.height;

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
