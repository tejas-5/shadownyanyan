using UnityEngine;

public class ShadowPlatformController : MonoBehaviour
{
    private Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ป้องกันไม่ให้ Player ตัวจริงเหยียบกล่องเงา
        if (collision.collider != null && collision.gameObject.name.Contains("Real"))
        {
            Physics2D.IgnoreCollision(collision.collider, col, true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // กลับมา detect อีกครั้งตอนออกจากการชน
        if (collision.collider != null && collision.gameObject.name.Contains("Real"))
        {
            Physics2D.IgnoreCollision(collision.collider, col, false);
        }
    }
}