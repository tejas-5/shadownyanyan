using UnityEngine;

public class RealBoxDirection : MonoBehaviour
{
    public Transform shadowBox; // กล่องเงา
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (shadowBox == null) return;

        Vector2 velocity = rb.linearVelocity;

        if (Mathf.Abs(velocity.x) > 0.1f) // เคลื่อนไปทางซ้ายหรือขวา
        {
            float angle = velocity.x > 0 ? 0f : 180f;

            // หมุนแบบทันที
            shadowBox.rotation = Quaternion.Euler(0f, 0f, angle);

            // ✅ ถ้าอยากให้ "หมุนนิ่มๆ" ใช้อันนี้แทนด้านบน:
            // Quaternion target = Quaternion.Euler(0f, 0f, angle);
            // shadowBox.rotation = Quaternion.Lerp(shadowBox.rotation, target, Time.deltaTime * 10f);
        }
    }
}