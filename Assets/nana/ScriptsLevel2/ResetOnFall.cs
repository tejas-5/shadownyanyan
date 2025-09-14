using UnityEngine;

public class ResetOnFall : MonoBehaviour
{
    public Transform player;
    public Transform shadow;

    public Transform playerStartPoint; // จุดเริ่มต้นของ Player
    public Transform shadowStartPoint; // จุดเริ่มต้นของ Shadow

    public PlatformFadeOut eraser;
    public StartEraseTrigger eraseTrigger;

    public Vector3 respawnOffset = new Vector3(0, 1f, 0); // Offset เพื่อ Spawn นอก Trigger

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == player)
        {
            Vector3 newPos = playerStartPoint.position + respawnOffset;
            player.position = newPos;

            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;

            Debug.Log($"📍 Player respawned at {newPos}");

            eraser.ResetPlatforms();
            eraseTrigger.ResetTrigger();
        }
        else if (other.transform == shadow)
        {
            Vector3 newPos = shadowStartPoint.position + respawnOffset;
            shadow.position = newPos;

            Rigidbody2D rb = shadow.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;

            Debug.Log($"📍 Shadow respawned at {newPos}");

            eraser.ResetPlatforms();
            eraseTrigger.ResetTrigger();
        }
    }
}