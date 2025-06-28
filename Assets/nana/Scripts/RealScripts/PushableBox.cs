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
        rb.mass = 10f;        // หนักพอดี
        rb.linearDamping = 2f;         // มีแรงต้าน พอหยุดได้เมื่อเลิกผลัก
        rb.angularDamping = 10f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.collider.GetComponent<PlayerController>();
        if (player != null)
        {
            if (!player.isRealPlayer)
            {
                rb.bodyType = RigidbodyType2D.Static;  // ห้ามผลักโดยเงา
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
        if (player != null && player.isRealPlayer)
        {
            rb.linearVelocity = Vector2.zero; // หยุดกล่องทันทีเมื่อเลิกชน
        }
    }
}