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
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}