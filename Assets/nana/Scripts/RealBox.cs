using UnityEngine;

public class RealBox : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector] public bool isInLight = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // ตรวจ Shadow Player เฉพาะ vertical contact
        if (collision.gameObject.CompareTag("Shadow"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.9f) // Shadow Player ยืนบนกล่อง
                {
                    // ล็อค horizontal ของ Shadow Player บนกล่อง
                    Rigidbody2D shadowRb = collision.rigidbody;
                    if (shadowRb != null)
                    {
                        shadowRb.linearVelocity = new Vector2(0, shadowRb.linearVelocity.y);
                    }
                }
            }
        }

        // Real Player → Physics ปกติ, สามารถดันกล่องได้ตามปกติ
    }

    // Trigger สำหรับ LightZone
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LightZone"))
            isInLight = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LightZone"))
            isInLight = false;
    }
}