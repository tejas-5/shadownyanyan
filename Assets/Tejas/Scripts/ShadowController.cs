using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class ShadowController : MonoBehaviour
{
    [Header("References")]
    public Transform realObject;
    public Transform lightSource;

    [Header("Projection Settings")]
    [Tooltip("How much the shadow scales per unit distance.")]
    public float scaleMultiplier = 0.1f;
    [Tooltip("How far beyond the real object to push the shadow.")]
    public float offsetDistance = 0.5f;

    private SpriteRenderer sprite;
    private Collider2D shadowCollider;
    private bool isInLight = false;

    [SerializeField] private LayerMask lightAreaMask;  // กำหนด Layer ของแสงใน Inspector
    [SerializeField] private float lightCheckRadius = 0.5f;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        shadowCollider = GetComponent<Collider2D>();

        sprite.enabled = false;
        shadowCollider.enabled = false;
    }

    void Update()
    {
        // ตรวจว่า realObject อยู่ในแสง (ใช้ OverlapCircle) 
        isInLight = Physics2D.OverlapCircle(realObject.position, lightCheckRadius, lightAreaMask);

        // เปิด/ปิด Sprite กับ Collider ของเงา ตามว่ามีแสงไหม
        sprite.enabled = isInLight;
        shadowCollider.enabled = isInLight;

        if (isInLight)
        {
            // คำนวณตำแหน่งเงาให้ห่างจากแสงในทิศทางเดียวกับ realObject
            Vector3 dir = realObject.position - lightSource.position;
            float distance = dir.magnitude;
            Vector3 projectedPos = realObject.position + dir.normalized * offsetDistance;
            transform.position = projectedPos;

            // ขยายเงาตามระยะทางจากแสง
            float newScale = 1f + distance * scaleMultiplier;
            transform.localScale = new Vector3(newScale, newScale, 1f);
        }
    }
}