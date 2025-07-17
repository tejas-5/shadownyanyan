using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

public class ShadowBoxController : MonoBehaviour
{
    public List<Light2D> shadowLights = new List<Light2D>();
    public float effectiveLightRadius = 5f;
    public float shadowOffsetX = 1f;

    private Collider2D col;
    private SpriteRenderer sprite;

    // อ้างอิงกล่องจริง
    public Transform realBoxTransform;
    private Rigidbody2D realBoxRb;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        SetVisible(false);

        if (realBoxTransform != null)
        {
            realBoxRb = realBoxTransform.GetComponent<Rigidbody2D>();
            if (realBoxRb == null)
                Debug.LogError("RealBox Rigidbody2D not found!");
        }
        else
        {
            Debug.LogError("realBoxTransform not assigned!");
        }
    }

    void Update()
    {
        bool isLit = false;
        foreach (Light2D light in shadowLights)
        {
            if (light != null && light.enabled)
            {
                float dist = Vector2.Distance(light.transform.position, transform.position);
                if (dist <= effectiveLightRadius)
                {
                    isLit = true;
                    break;
                }
            }
        }
        SetVisible(isLit);

        if (realBoxRb != null && realBoxTransform != null)
        {
            Vector3 shadowPos = realBoxTransform.position;

            float vx = realBoxRb.linearVelocity.x;

            if (vx > 0.05f)
            {
                shadowPos.x += shadowOffsetX;
                sprite.flipX = false;
            }
            else if (vx < -0.05f)
            {
                shadowPos.x -= shadowOffsetX;
                sprite.flipX = true;
            }
            else
            {
                // กล่องจริงไม่ขยับ เงาอยู่ตรงกลาง
                shadowPos.x = realBoxTransform.position.x;
            }

            transform.position = shadowPos;
        }
    }

    void SetVisible(bool visible)
    {
        col.enabled = visible;
        sprite.enabled = visible;
    }
}
