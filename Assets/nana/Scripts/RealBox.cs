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
        // Shadow player logic
        if (collision.gameObject.CompareTag("Shadow"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // If Shadow is on top of the box (normal pointing upward)
                if (contact.normal.y > 0.9f)
                {
                    // Stop Shadow's horizontal movement when standing on box
                    Rigidbody2D shadowRb = collision.rigidbody;
                    if (shadowRb != null)
                    {
                        shadowRb.linearVelocity = new Vector2(0, shadowRb.linearVelocity.y);
                    }
                }
                else
                {
                    // Prevent Shadow from pushing box: negate horizontal force
                    rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
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
