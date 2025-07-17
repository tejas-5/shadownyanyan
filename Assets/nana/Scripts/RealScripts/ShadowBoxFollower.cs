using UnityEngine;

public class ShadowBoxFollower : MonoBehaviour
{
    public Transform realBox; // กล่องจริง
    public float flipThreshold = 0.05f; // ค่าความเร็วที่ถือว่า “กำลังเคลื่อน”

    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    void Start()
    {
        if (realBox == null)
        {
            Debug.LogError("❌ โปรดใส่ realBox ให้กับ ShadowBoxDirectionController");
            enabled = false;
            return;
        }

        rb = realBox.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        // เริ่มต้นอยู่ตรงกลาง
        transform.position = realBox.position;
    }

    void Update()
    {
        if (rb == null) return;

        // ตำแหน่งตรงกลาง
        transform.position = realBox.position;

        // เคลื่อนไปขวา → ไม่ flip
        if (rb.linearVelocity.x > flipThreshold)
        {
            sprite.flipX = false;
        }
        // เคลื่อนไปซ้าย → flip
        else if (rb.linearVelocity.x < -flipThreshold)
        {
            sprite.flipX = true;
        }
        // หยุดนิ่ง → ไม่เปลี่ยน
    }
}
