using System.Collections;
using UnityEngine;

public class WorldCameraController : MonoBehaviour
{
    [Header("Players")]
    public GameObject realPlayer;
    public GameObject shadowPlayer;

    [Header("Camera Settings")]
    public float smoothSpeed = 5f;
    public float fixedZ = -10f;
    public float fixedY = -6.5f;   // สำหรับ Shadow / ล็อก Y
    public float minX = 0f;
    public float maxX = 30f;
    public float minY = -6.5f;     // กันกล้องต่ำเกิน

    private bool isControllingReal = true;
    private Transform target;

    void Start()
    {
        // เปิดทั้งสองตัว
        realPlayer.SetActive(true);
        shadowPlayer.SetActive(true);

        // วาง Shadow ข้าง Player จริง
        shadowPlayer.transform.position = realPlayer.transform.position + Vector3.right * 1.5f;

        // ป้องกันชนกัน
        Physics2D.IgnoreCollision(
            realPlayer.GetComponent<Collider2D>(),
            shadowPlayer.GetComponent<Collider2D>(),
            true
        );
    }

    void Update()
    {
        // Space = สลับร่าง
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isControllingReal = !isControllingReal;
            SetActivePlayer(isControllingReal ? realPlayer : shadowPlayer);
        }

        // R = รีเซ็ต
        if (Input.GetKeyDown(KeyCode.R))
        {
            isControllingReal = true;
            shadowPlayer.transform.position = realPlayer.transform.position + Vector3.right * 1.5f;
            SetActivePlayer(realPlayer);
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        // X ตาม target, clamp min/max
        float targetX = Mathf.Clamp(target.position.x, minX, maxX);

        // Y ตาม Player จริง, Shadow ใช้ fixedY
        float targetY = (target == realPlayer.transform) ? Mathf.Max(target.position.y, minY) : fixedY;

        Vector3 desiredPosition = new Vector3(targetX, targetY, fixedZ);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }

    void SetActivePlayer(GameObject active)
    {
        // เปิด/ปิดการควบคุม
        SetPlayerControl(active, true);
        SetPlayerControl(active == realPlayer ? shadowPlayer : realPlayer, false);

        // ตั้ง target ของกล้อง
        target = active.transform;

        // Snap กล้องไปทันที
        SnapCameraToTarget();
    }

    void SnapCameraToTarget()
    {
        if (target == null) return;

        float targetX = Mathf.Clamp(target.position.x, minX, maxX);
        float targetY = (target == realPlayer.transform) ? Mathf.Max(target.position.y, minY) : fixedY;

        transform.position = new Vector3(targetX, targetY, fixedZ);
    }

    void SetPlayerControl(GameObject obj, bool active)
    {
        var pc = obj.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = active;
    }

    void IgnoreCollisionBetween(GameObject a, GameObject b)
    {
        var colA = a.GetComponent<Collider2D>();
        var colB = b.GetComponent<Collider2D>();
        if (colA != null && colB != null)
        {
            Physics2D.IgnoreCollision(colA, colB, true);
        }
    }

    void IgnoreCollisionByTag(string tagA, string tagB)
    {
        GameObject[] objsA = GameObject.FindGameObjectsWithTag(tagA);
        GameObject[] objsB = GameObject.FindGameObjectsWithTag(tagB);

        foreach (var objA in objsA)
        {
            var colA = objA.GetComponent<Collider2D>();
            if (colA == null) continue;

            foreach (var objB in objsB)
            {
                var colB = objB.GetComponent<Collider2D>();
                if (colB == null) continue;

                Physics2D.IgnoreCollision(colA, colB, true);
            }
        }
    }
}