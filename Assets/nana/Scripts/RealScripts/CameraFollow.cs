using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float fixedY = -6.5f;
    public float fixedZ = -10f;

    [Header("Limit X Movement")]
    public bool limitX = true;
    public float minX = 0f;
    public float maxX = 30f;

    void LateUpdate()
    {
        if (target == null) return;

        // ตำแหน่งที่กล้องควรอยู่
        float targetX = target.position.x;

        if (limitX)
        {
            targetX = Mathf.Clamp(targetX, minX, maxX);
        }

        Vector3 desiredPosition = new Vector3(targetX, fixedY, fixedZ);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}