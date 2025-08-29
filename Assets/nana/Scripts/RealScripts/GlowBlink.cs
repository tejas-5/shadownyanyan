using UnityEngine;

public class GlowBlink : MonoBehaviour
{
    public Color baseColor = Color.yellow;   // สีปกติ (เหลืองสำหรับกุญแจ)
    public Color glowColor = Color.white;   // สีเรืองแสง
    public float speed = 2f;                // ความเร็วในการวิ๊บ

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // เปลี่ยนสีไปมาระหว่าง baseColor และ glowColor
        sr.color = Color.Lerp(baseColor, glowColor, Mathf.PingPong(Time.time * speed, 1));
    }
}