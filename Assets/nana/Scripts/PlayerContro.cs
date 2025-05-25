using UnityEngine;
public class PlayerContro : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float climbSpeed = 3f;
    private Rigidbody2D rb;
    private Collider2D coll;
    private bool isClimbing = false;
    public LayerMask groundLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        bool isGrounded = coll.IsTouchingLayers(groundLayer);
        Debug.Log("Grounded: " + isGrounded);
        if (isClimbing)
        {
            rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * climbSpeed);
            rb.gravityScale = 0f;
        }
        else
        {
            rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
            rb.gravityScale = 1f;
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Debug.Log("Jumping!");
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
        }
    }
}