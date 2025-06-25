using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float fixedY = -10f;  // Adjust this based on your scene
    public float fixedZ = -10f;

    [Header("Limit X Movement")]
    public bool limitX = true;
    public float minX = 0f;
    public float maxX = 30f;

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: No target assigned!");
            return;
        }

        // Log the camera's target and its position
        Debug.Log("Camera following: " + target.name + " at " + target.position);

        float targetX = target.position.x;

        if (limitX)
        {
            targetX = Mathf.Clamp(targetX, minX, maxX);
        }

        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, fixedZ);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        Debug.Log("CameraFollow: Set target to " + (target != null ? target.name : "null"));
    }
}