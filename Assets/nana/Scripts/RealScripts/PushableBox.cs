using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PushableBox : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // ตั้งค่าเริ่มต้น
        rb.mass = 10f;
        rb.linearDamping = 2f;           // linear damping
        rb.angularDamping = 10f;   // angular damping
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void FixedUpdate()
    {
        if (rb.bodyType == RigidbodyType2D.Kinematic)
        {
            rb.linearVelocity = Vector2.zero; // ป้องกันกล่องลื่นไหล
            rb.angularVelocity = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Shadow"))
        {
            // ถ้าเป็นเงา → ไม่ให้ดันได้
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        else if (collision.collider.CompareTag("Player"))
        {
            // ถ้าเป็นผู้เล่นจริง → ดันได้
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Shadow"))
        {
            // เงาออกจากกล่อง กล่องกลับมาเคลื่อนที่ได้
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        else if (collision.collider.CompareTag("Player"))
        {
            // ผู้เล่นจริงออกจากกล่อง หยุดกล่อง
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
