using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f; // Adjust jump height [[7]]
    private Rigidbody2D rb;
    private Vector2 movement;
    
    // Ground check setup
    public Transform groundCheck; // Assign in Inspector (position at character's feet)
    public float checkRadius = 0.2f;
    public LayerMask whatIsGround; // Assign the ground layer here
    private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        
        // Jump input [[2]][[7]]
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Instant vertical velocity [[7]]
        }
    }

    void FixedUpdate()
    {
        // Check if grounded using a small circle at the feet [[3]]
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        // Horizontal movement via velocity [[3]]
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
    }
}