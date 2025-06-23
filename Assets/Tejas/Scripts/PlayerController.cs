using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    public Transform groundCheck;
    public Vector2 checkSize = new Vector2(0.5f, 0.1f);
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;
    private bool jumpPressed = false;
    private SwitchController currentSwitch;



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

        if (Input.GetKeyDown(KeyCode.E) && currentSwitch != null)
        {
            currentSwitch.ToggleLift();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Switch"))
        {
            currentSwitch = col.GetComponent<SwitchController>();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Switch"))
        {
            currentSwitch = null;
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, checkSize);
    }
}