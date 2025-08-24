using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(SpriteRenderer))]
public class ShadowBoxController : MonoBehaviour
{
    public Transform realBox;       // กล่องจริง
    public Light2D lightSource;     // ไฟ
    public float lightRadius = 5f;  // ระยะไฟที่เงาจะปรากฏ
    public float offsetX = 1.5f;    // เงาอยู่ข้างกล่อง
    public float shadowHeightOffset = 0.1f; // ยกสูงจากพื้น
    public float smoothSpeed = 5f;  // ความเร็ว Lerp เงา

    private SpriteRenderer sr;
    private float lastBoxX;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        if (!realBox || !lightSource)
        {
            Debug.LogError("Assign realBox & lightSource!");
            enabled = false;
            return;
        }
        lastBoxX = realBox.position.x;
    }

    void Update()
    {
        // ตรวจสอบระยะไฟ
        float dist = Vector2.Distance(realBox.position, lightSource.transform.position);
        sr.enabled = dist <= lightRadius;
        if (!sr.enabled) return;

        // หาทิศทางกล่องจริง
        float dir = (realBox.position.x - lastBoxX) >= 0 ? 1f : -1f;
        lastBoxX = realBox.position.x;

        // ตำแหน่งเงา = ข้างกล่องจริง (ซ้าย/ขวา ตาม dir)
        Vector3 targetPos = new Vector3(
            realBox.position.x + offsetX * dir,
            realBox.position.y + shadowHeightOffset,
            realBox.position.z
        );

        // Smooth Lerp แค่ Visual ของเงา
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
    }
}