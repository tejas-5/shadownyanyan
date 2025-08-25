using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShadowBoxFollower : MonoBehaviour
{
    public Transform realBox;         // RealBox ที่เงาจะตาม
    public float followHeight = 0f;   // ความสูงเหนือพื้นของกล่องเงา
    public Vector3 offset = new Vector3(1.5f, 0f, 0f);

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private BoxCollider2D col;        // <-- Add reference to BoxCollider2D

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

        // ShadowBox Kinematic → ไม่ถูก Gravity ดึง ไม่ดันกล่อง
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
        if (realBox == null) return;

        // ตำแหน่ง X,Z = ตาม RealBox + offset
        float x = realBox.position.x + offset.x;
        float z = realBox.position.z + offset.z;

        // Y = สูงกว่าพื้น / ตาม RealBox (ทำให้ขึ้นกล่องได้)
        float y = Mathf.Max(transform.position.y, realBox.position.y + followHeight);

        transform.position = new Vector3(x, y, z);

        // ปรากฏเฉพาะตอน RealBox อยู่ในไฟ
        RealBox rbScript = realBox.GetComponent<RealBox>();
        bool shouldBeVisible = rbScript != null && rbScript.isInLight;

        sr.enabled = shouldBeVisible;
        if (col != null)
            col.enabled = shouldBeVisible;
    }
}
