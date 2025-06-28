using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowBoxController : MonoBehaviour
{
    public Light2D shadowLight;
    public float effectiveLightRadius = 5f; // รัศมีแสงไฟที่กล่องยังโผล่
    private Collider2D col;
    private SpriteRenderer sprite;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        SetVisible(false); // เริ่มต้นปิดกล่องเงา
    }

    void Update()
    {
        if (shadowLight == null || !shadowLight.enabled)
        {
            SetVisible(false);
            return;
        }

        Vector2 lightPos = shadowLight.transform.position;
        Vector2 boxPos = transform.position;
        float distance = Vector2.Distance(lightPos, boxPos);

        if (distance <= effectiveLightRadius)
        {
            SetVisible(true);
        }
        else
        {
            SetVisible(false);
        }
    }

    void SetVisible(bool visible)
    {
        col.enabled = visible;
        sprite.enabled = visible;
    }
}