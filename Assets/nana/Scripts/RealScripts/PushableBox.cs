using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PushableBox : MonoBehaviour
{
    public bool hasLight = true;  // ไฟส่องอยู่หรือไม่

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // ตั้งค่าความหนักและแรงเสียดทาน
        rb.mass = 10f;
        rb.linearDamping = 2f;
        rb.angularDamping = 10f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.bodyType = RigidbodyType2D.Dynamic; // ตั้งเริ่มต้นให้ Dynamic
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.collider.GetComponent<PlayerController>();
        if (player != null)
        {
            if (!player.isRealPlayer)
            {
                // แก้ไข: ไม่ตั้ง Static แต่ใช้ Kinematic หรือ Dynamic
                rb.bodyType = RigidbodyType2D.Kinematic;  // เงาไม่ผลักกล่องได้ แต่ยังมี Collider ทำงาน
            }
            else
            {
                rb.bodyType = RigidbodyType2D.Dynamic;  // ให้ผลักได้
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        PlayerController player = collision.collider.GetComponent<PlayerController>();
        if (player != null)
        {
            // เมื่อเงาออกจากกล่อง กลับไป Dynamic
            if (!player.isRealPlayer)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
            // เมื่อผู้เล่นจริงเลิกชน หยุดกล่องทันที
            else if (player.isRealPlayer)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
    }
}