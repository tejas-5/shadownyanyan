using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public bool isRealPlayer = true;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.15f;

    [Header("Debug")]
    public bool isGrounded = false; // Show in Inspector
    public bool canControl = true;  // Disable when inactive

    private Animator anim;
    private Rigidbody2D rb;
    private Collider2D playerCol;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<Collider2D>();

        // Create GroundCheck automatically if missing
        if (groundCheck == null)
        {
            GameObject go = new GameObject("GroundCheck");
            go.transform.parent = transform;
            go.transform.localPosition = new Vector3(0, -0.5f, 0);
            groundCheck = go.transform;
        }

        // Shadow Player → Ignore collision with RealBox
        if (!isRealPlayer)
        {
            GameObject[] realBoxes = GameObject.FindGameObjectsWithTag("RealBox");
            foreach (var box in realBoxes)
            {
                Collider2D boxCol = box.GetComponent<Collider2D>();
                if (boxCol != null)
                    Physics2D.IgnoreCollision(playerCol, boxCol, true);
            }
        }
    }

    void Update()
    {
        if (!canControl) return;

        // Horizontal movement
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // Flip character based on direction
        if (moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Update Animator
        anim.SetFloat("Speed", Mathf.Abs(moveX));
        anim.SetBool("IsJumping", !isGrounded);
    }

    void FixedUpdate()
    {
        string[] tagsToCheck = isRealPlayer
            ? new string[] { "Ground", "PushableBox", "ShadowBox", "Lift", "ShadowGround" }
            : new string[] { "Ground", "RealBox", "ShadowBox", "Lift", "ShadowGround" };

        Collider2D[] hits = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius);
        isGrounded = false;

        foreach (var hit in hits)
        {
            foreach (var tag in tagsToCheck)
            {
                if (hit.CompareTag(tag))
                {
                    if (hit.bounds.max.y <= groundCheck.position.y + 0.05f) // tolerance
                    {
                        isGrounded = true;
                        break;
                    }
                }
            }
            if (isGrounded) break;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
