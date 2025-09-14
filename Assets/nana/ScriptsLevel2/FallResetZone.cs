using UnityEngine;

public class FallResetZone : MonoBehaviour
{
    public Transform respawnPoint; // จุดเริ่มต้นที่ผู้เล่นจะกลับไป

    public PlatformFadeOut eraser;
    public StartEraseTrigger eraseTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.position;

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;

            Debug.Log("🔁 Player fell and was reset.");

            eraser.ResetPlatforms();
            eraseTrigger.ResetTrigger();
        }
    }
}
