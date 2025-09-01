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
    public bool isGrounded = false; // แสดงใน Inspector
    public bool canControl = true;  // ปิดเมื่อไม่ใช่ตัว active

    public Animator animator;

    private Rigidbody2D rb;
    private Collider2D playerCol;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<Collider2D>();

        // สร้าง GroundCheck อัตโนมัติถ้าไม่มี
        if (groundCheck == null)
        {
            GameObject go = new GameObject("GroundCheck");
            go.transform.parent = transform;
            go.transform.localPosition = new Vector3(0, -0.5f, 0);
            groundCheck = go.transform;
        }

        // Shadow Player → Ignore horizontal collision กับ RealBox
        if (!isRealPlayer)
        {
            GameObject[] realBoxes = GameObject.FindGameObjectsWithTag("RealBox");
            foreach (var box in realBoxes)
            {
                Collider2D boxCol = box.GetComponent<Collider2D>();
                if (boxCol != null)
                    Physics2D.IgnoreCollision(playerCol, boxCol, true); // ignore collision
            }
        }
    }

    void Update()
    {
        

        float moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // ตรวจสอบทิศทางการเดินและหันตัวละคร
        if (moveX > 0)
        {
            // เดินไปขวา → หมุนตัวละครไปทางขวา
            transform.rotation = Quaternion.Euler(0, 0, 0); // หันขวา (Rotation ที่ 0 องศา)
        }
        else if (moveX < 0)
        {
            // เดินไปซ้าย → หมุนตัวละครไปทางซ้าย
            transform.rotation = Quaternion.Euler(0, 180, 0); // หันซ้าย (Rotation ที่ 180 องศา)
        }


        // Jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
           

        // Update Animator
        animator.SetFloat("MoveX", Mathf.Abs(moveX));
        animator.SetBool("isGrounded", isGrounded);
    }

    void FixedUpdate()
    {
        string[] tagsToCheck = isRealPlayer
            ? new string[] { "Ground", "PushableBox", "ShadowBox","Lift" , "ShadowGround" }
            : new string[] { "Ground", "RealBox", "ShadowBox", "Lift", "ShadowGround" };

        Collider2D[] hits = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius);
        isGrounded = false;

        foreach (var hit in hits)
        {
            foreach (var tag in tagsToCheck)
            {
                if (hit.CompareTag(tag))
                {
                    // Check if hit collider is below player
                    if (hit.bounds.max.y <= groundCheck.position.y + 0.05f) // add slight tolerance
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
