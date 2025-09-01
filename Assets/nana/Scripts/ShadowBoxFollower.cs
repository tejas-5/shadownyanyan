using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShadowBoxFollower : MonoBehaviour
{
    public Transform realBox;            // RealBox ที่เงาจะตาม
    public Transform lightSource;        // <-- Reference to the light source
    public float followHeight = 0f;      // ความสูงเหนือพื้นของกล่องเงา
    public Vector3 offset = new Vector3(1.5f, 0f, 0f);

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private BoxCollider2D col;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (sr != null)
            sr.enabled = false;
        if (col != null)
            col.enabled = false;
    }

    void LateUpdate()
    {
        if (realBox == null || lightSource == null) return;

        // Get RealBox script and check if it's in light
        RealBox rbScript = realBox.GetComponent<RealBox>();
        bool shouldBeVisible = rbScript != null && rbScript.isInLight;

        // Only change offset if in light
        if (shouldBeVisible)
        {
            // Compare x positions
            if (realBox.position.x > lightSource.position.x)
                offset.x = 1.5f;
            else
                offset.x = -1.5f; // You can use another value like 0.5f if you prefer
        }

        // Update position
        float x = realBox.position.x + offset.x;
        float z = realBox.position.z + offset.z;
        float y = Mathf.Max(transform.position.y, realBox.position.y + followHeight);
        transform.position = new Vector3(x, y, z);

        // Update visibility and collider
        sr.enabled = shouldBeVisible;
        if (col != null)
            col.enabled = shouldBeVisible;
    }
}