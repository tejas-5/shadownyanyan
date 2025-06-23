using UnityEngine;

public class ShadowPlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    public Transform groundCheck;
    public Vector2 checkSize = new Vector2(0.5f, 0.1f);
    public LayerMask whatIsGround;  // ??? Layer ShadowWorld ??????????????????

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;
    private bool jumpPressed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, checkSize, 0f, whatIsGround);
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);

        if (jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPressed = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, checkSize);
    }
}

