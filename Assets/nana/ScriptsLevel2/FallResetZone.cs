using UnityEngine;

public class FallResetZone : MonoBehaviour
{
    public Transform respawnPoint;   // จุดเกิดใหม่ของผู้เล่น
    public PlatformFadeOut eraser;
    public StartEraseTrigger eraseTrigger;

    public Vector3 respawnOffset = new Vector3(0, 1f, 0); // offset เพื่อ spawn นอก trigger

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ✅ Respawn player + offset
            Vector3 newPos = respawnPoint.position + respawnOffset;
            other.transform.position = newPos;
            Debug.Log($"📍 Player respawned at {newPos}");

            // รีเซ็ตความเร็ว
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;

            Debug.Log("🔁 Player fell and was reset.");

            // รีเซ็ต Platform + Trigger
            eraser.ResetPlatforms();
            eraseTrigger.ResetTrigger();
        }
    }
}