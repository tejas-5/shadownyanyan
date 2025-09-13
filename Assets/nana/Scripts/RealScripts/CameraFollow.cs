using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // Player หรือ Shadow
    public float smoothSpeed = 10f;     // ค่ายิ่งมาก = กล้องตามเร็วขึ้น
    public float fixedZ = -10f;         // กล้อง 2D ปกติ Z=-10

    [Header("Y Options")]
    public bool lockY = false;          // true = กล้องไม่ตาม Y
    public float fixedY = -6.5f;

    [Header("Limit X Movement")]
    public bool limitX = true;
    public float minX = 0f;
    public float maxX = 30f;

    void LateUpdate()
    {
        if (target == null) return;

        float targetX = target.position.x;
        float targetY = lockY ? fixedY : target.position.y;

        if (limitX)
            targetX = Mathf.Clamp(targetX, minX, maxX);

        Vector3 desiredPosition = new Vector3(targetX, targetY, fixedZ);

        // กล้องเลื่อนตามอย่างนุ่มนวล
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        Debug.Log("CameraFollow: Target set to " + (target != null ? target.name : "null"));
    }
}