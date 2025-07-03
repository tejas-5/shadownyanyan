using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

public class ShadowBoxController : MonoBehaviour
{
    public List<Light2D> shadowLights = new List<Light2D>(); // ✅ ไฟหลายดวง
    public float effectiveLightRadius = 5f;

    private Collider2D col;
    private SpriteRenderer sprite;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        SetVisible(false); // เริ่มต้นปิด
    }

    void Update()
    {
        bool isLit = false;

        foreach (Light2D light in shadowLights)
        {
            if (light != null && light.enabled)
            {
                float distance = Vector2.Distance(light.transform.position, transform.position);
                if (distance <= effectiveLightRadius)
                {
                    isLit = true;
                    break; // ไม่ต้องเช็กต่อ ถ้ามีดวงนึงเข้าใกล้พอ
                }
            }
        }

        SetVisible(isLit);
    }

    void SetVisible(bool visible)
    {
        col.enabled = visible;
        sprite.enabled = visible;
    }
}