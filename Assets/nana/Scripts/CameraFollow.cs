using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Player transform
    public float smoothSpeed = 0.125f;
    public Vector3 offset;         // Camera offset (e.g. new Vector3(0, 0, -10))

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
