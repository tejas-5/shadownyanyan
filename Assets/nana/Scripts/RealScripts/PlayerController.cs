using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isRealPlayer = true;  // ✅ เพิ่มตรงนี้

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundRadius = 0.2f;

    private Rigidbody2D rb;
    private Collider2D col;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Start()
    {
        if (isRealPlayer) // ✅ เช็คว่าเฉพาะตัวจริงเท่านั้นที่จะ Ignore กล่องเงา
        {
            GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            foreach (GameObject obj in allObjects)
            {
                if (obj.name.Contains("ShadowPlatform"))
                {
                    Collider2D shadowCol = obj.GetComponent<Collider2D>();
                    Collider2D playerCol = GetComponent<Collider2D>();

                    if (shadowCol != null && playerCol != null)
                    {
                        Physics2D.IgnoreCollision(playerCol, shadowCol, true);
                    }
                }
            }
        }
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        // เช็คว่าชนพื้นจริงๆ โดยใช้ OverlapCircle รอบๆ จุด groundCheck
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        // กระโดดได้เฉพาะตอนแตะพื้นจริงเท่านั้น
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
            }
        }

        // ตัวอย่างเช็คกล่องข้างหน้า (แก้ไขให้เหมาะกับเกม)
        if (move != 0 && isRealPlayer)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * move, 0.7f, LayerMask.GetMask("PushableBox"));
            if (hit.collider != null)
            {
                PushableBox box = hit.collider.GetComponent<PushableBox>();
                if (box != null)
                {
                    // ถ้าเป็นกล่องเงา และไม่มีไฟ ก็ห้ามขยับ
                    if (!box.hasLight)
                    {
                        move = 0; // หยุดการเคลื่อนที่ผู้เล่นไปชนกล่องเงานี้
                    }
                }
            }
        }
    }
}
   