using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Ground check setup (box)
    public Transform groundCheck; // Assign in Inspector (center of box at character's feet)
    public Vector2 checkSize = new Vector2(0.5f, 0.1f); // Width and height of the box
    public LayerMask whatIsGround;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Box-based ground check
        isGrounded = Physics2D.OverlapBox(groundCheck.position, checkSize, 0f, whatIsGround);

        // Move horizontally
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
    }

    // Draw box gizmo in editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, checkSize);
    }
}
