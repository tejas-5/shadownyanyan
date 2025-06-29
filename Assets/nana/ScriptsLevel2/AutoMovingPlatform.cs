using UnityEngine;

public class AutoMovingPlatform : MonoBehaviour
{
    public float pushSpeed = 3f; // ความเร็วที่ผลัก Player
    public Vector2 pushDirection = Vector2.right; // ทิศทางการไหล (เปลี่ยนเป็น Vector2.left ถ้าอยากไหลไปซ้าย)

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Shadow"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // ผลักตัวละครไปด้านข้างแบบ Conveyor
                rb.linearVelocity = new Vector2(pushDirection.normalized.x * pushSpeed, rb.linearVelocity.y);
            }
        }
    }
}