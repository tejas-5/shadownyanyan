using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isRealPlayer = true;

    public float moveSpeed = 5f;
    public float climbSpeed = 3f;      // เพิ่ม climbSpeed
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundRadius = 0.3f;

    private Rigidbody2D rb;
    private Collider2D col;
    private bool isGrounded;
    private bool hasJumped = false;
    private bool isClimbing = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Start()
    {
        if (isRealPlayer)
        {
            GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            foreach (GameObject obj in allObjects)
            {
                if (obj.CompareTag("Shadow"))
                {
                    Collider2D shadowCol = obj.GetComponent<Collider2D>();
                    if (shadowCol != null && col != null)
                    {
                        Physics2D.IgnoreCollision(col, shadowCol, true);
                    }
                }
            }
        }
    }

    public void EnableClimbing(bool canClimb)
    {
        isClimbing = canClimb;
        rb.gravityScale = canClimb ? 0 : 1;
        if (canClimb)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // เช็คว่ากระโดดได้แค่ครั้งเดียวก่อนแตะพื้นใหม่
        Collider2D groundHit = Physics2D.OverlapCircle(groundCheck.position, groundRadius);
        bool wasGrounded = isGrounded;
        isGrounded = groundHit != null;

        if (isGrounded)
        {
            hasJumped = false;  // แตะพื้นแล้ว reset สถานะกระโดด
        }

        if (isClimbing)
        {
            // ปีนขึ้นลงบันได
            rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * climbSpeed);
        }
        else
        {
            // เดินตามปกติ
            rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

            // กระโดด
            if (Input.GetKeyDown(KeyCode.W) && isGrounded && !hasJumped)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                hasJumped = true; // บอกว่ากระโดดแล้ว ต้องรอแตะพื้นก่อนถึงจะกระโดดอีก
            }
        }
    }
}
