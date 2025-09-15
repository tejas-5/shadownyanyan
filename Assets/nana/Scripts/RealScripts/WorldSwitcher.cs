using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    public GameObject realPlayer;
    public GameObject shadowPlayer;
    public CameraFollow cameraFollow;

    private bool isControllingReal = true;

    void Start()
    {
        if (cameraFollow == null)
            cameraFollow = Camera.main.GetComponent<CameraFollow>();

        realPlayer.SetActive(true);
        shadowPlayer.SetActive(true);

        // เริ่มให้ Shadow อยู่ข้าง ๆ Player
        shadowPlayer.transform.position = realPlayer.transform.position + Vector3.right * 1.5f;

        SetPlayerControl(realPlayer, true);
        SetPlayerControl(shadowPlayer, false);

        cameraFollow?.SetTarget(realPlayer.transform);

        // ป้องกันการชนกัน
        Collider2D realCol = realPlayer.GetComponent<Collider2D>();
        Collider2D shadowCol = shadowPlayer.GetComponent<Collider2D>();
        if (realCol != null && shadowCol != null)
            Physics2D.IgnoreCollision(realCol, shadowCol, true);
    }

    void Update()
    {
        // SPACE = สลับร่าง
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isControllingReal = !isControllingReal;
            GameObject activePlayer = isControllingReal ? realPlayer : shadowPlayer;
            GameObject inactivePlayer = isControllingReal ? shadowPlayer : realPlayer;

            SetPlayerControl(activePlayer, true);
            SetPlayerControl(inactivePlayer, false);

            cameraFollow?.SetTarget(activePlayer.transform);
        }

        // R = รีเซ็ตตำแหน่ง
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayers();
        }
    }

    void SetPlayerControl(GameObject obj, bool active)
    {
        var pc = obj.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = active;

        var rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;

            // ❌ อย่าปิดฟิสิกส์ตัวที่ไม่ควบคุม
            // rb.isKinematic = !active;

            // ✅ ปล่อยให้ Physics ทำงานทั้งคู่
            // (ตัวที่ไม่ได้บังคับจะหยุดเองเพราะ PlayerController ถูกปิด)
            rb.isKinematic = false;
        }
    }

    void ResetPlayers()
    {
        realPlayer.transform.position = Vector3.zero;
        shadowPlayer.transform.position = realPlayer.transform.position + Vector3.right * 1.5f;

        Rigidbody2D rb1 = realPlayer.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = shadowPlayer.GetComponent<Rigidbody2D>();
        if (rb1 != null) rb1.linearVelocity = Vector2.zero;
        if (rb2 != null) rb2.linearVelocity = Vector2.zero;

        isControllingReal = true;

        SetPlayerControl(realPlayer, true);
        SetPlayerControl(shadowPlayer, false);

        cameraFollow?.SetTarget(realPlayer.transform);
    }
}