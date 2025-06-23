using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject shadowVersion;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Collider2D col;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void SetMode(bool isRealWorld)
    {
        spriteRenderer.enabled = isRealWorld;
        rb.simulated = isRealWorld;
        col.enabled = isRealWorld;

        // ไม่ปิด GameObject เงา!
        shadowVersion.GetComponent<SpriteRenderer>().enabled = !isRealWorld;
        shadowVersion.GetComponent<Collider2D>().enabled = !isRealWorld;
        shadowVersion.GetComponent<Rigidbody2D>().simulated = !isRealWorld;
    }
}