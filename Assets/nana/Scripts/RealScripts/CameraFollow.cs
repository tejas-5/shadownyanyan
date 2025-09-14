using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float fixedZ = -10f;

    [Header("Limit X Movement")]
    public bool limitX = true;
    public float minX = 0f;
    public float maxX = 30f;

    private Vector3 extraOffset = Vector3.zero;
    private Vector3 zoneOffset = Vector3.zero; // current zone offset
    private bool shadowInZone = false;

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: No target assigned!");
            return;
        }

        float targetX = target.position.x;
        if (limitX) targetX = Mathf.Clamp(targetX, minX, maxX);

        Vector3 desiredPosition = new Vector3(
            target.position.x + 3 + extraOffset.x,
            target.position.y + 3 + extraOffset.y,
            fixedZ + extraOffset.z
        );

        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothedPosition;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;

        if (target != null && target.CompareTag("Player"))
        {
            // Real player → no offset
            extraOffset = Vector3.zero;
        }
        else if (target != null && target.CompareTag("Shadow"))
        {
            // Shadow player → apply zone offset if inside
            extraOffset = shadowInZone ? zoneOffset : Vector3.zero;
        }

        Debug.Log("CameraFollow: Set target to " + (target != null ? target.name : "null"));
    }

    public void SetZoneOffset(Vector3 offset, bool insideZone)
    {
        shadowInZone = insideZone;
        zoneOffset = offset;

        if (target != null && target.CompareTag("Shadow"))
        {
            extraOffset = insideZone ? zoneOffset : Vector3.zero;
        }
    }
}
