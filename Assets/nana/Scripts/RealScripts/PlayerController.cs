using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isRealPlayer = true;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Collider2D col;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        if (!isRealPlayer)
        {
            // 👉 ห้าม Player เงา ชนกับกล่องจริง
            GameObject[] realBoxes = GameObject.FindGameObjectsWithTag("PushableBox");
            foreach (var box in realBoxes)
            {
                Collider2D boxCol = box.GetComponent<Collider2D>();
                if (boxCol != null)
                    Physics2D.IgnoreCollision(col, boxCol);
            }
        }
        else
        {
            // 👉 ห้าม Player จริง ชนกับกล่องเงา
            GameObject[] shadowBoxes = GameObject.FindGameObjectsWithTag("ShadowBox");
            foreach (var box in shadowBoxes)
            {
                Collider2D boxCol = box.GetComponent<Collider2D>();
                if (boxCol != null)
                    Physics2D.IgnoreCollision(col, boxCol);
            }
        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}