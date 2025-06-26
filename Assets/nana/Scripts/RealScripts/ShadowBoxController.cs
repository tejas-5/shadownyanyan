using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowBoxController : MonoBehaviour
{
    public Light2D shadowLight;
    private Collider2D col;
    private SpriteRenderer sprite;

    public float effectiveLightRadius = 5f;

    // Optional: Tag for objects that block light
    public string obstacleTag = "Obstacle"; // Set this in Inspector or hardcode

    void Awake()
    {
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();

        if (col == null) Debug.LogError("No Collider2D found");
        if (sprite == null) Debug.LogError("No SpriteRenderer found");
    }

    void Update()
    {
        if (shadowLight == null) return;

        Vector2 lightPos = shadowLight.transform.position;
        Vector2 boxPos = transform.position;

        float distance = Vector2.Distance(lightPos, boxPos);

        if (distance <= effectiveLightRadius)
        {
            // Raycast without filtering by LayerMask
            RaycastHit2D hit = Physics2D.Raycast(lightPos, boxPos - lightPos, distance);

            if (hit.collider == null || hit.collider.CompareTag(obstacleTag) == false)
            {
                // Either nothing hit, or hit something not tagged as obstacle
                SetVisible(true);
                return;
            }
        }

        SetVisible(false);
    }

    void SetVisible(bool visible)
    {
        col.enabled = visible;
        sprite.enabled = visible;
    }
}