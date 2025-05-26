using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))] // Or change to Collider2D if you're not using specifically BoxCollider2D
public class ShadowController : MonoBehaviour
{
    [Header("References")]
    public Transform realObject;      // The “real” counterpart
    public Transform lightSource;     // Your PointLight transform
    public Collider2D lightTrigger;   // Assign the light's trigger collider here

    [Header("Projection Settings")]
    [Tooltip("How much the shadow scales per unit distance.")]
    public float scaleMultiplier = 0.1f;
    [Tooltip("How far beyond the real object to push the shadow.")]
    public float offsetDistance = 0.5f;

    private SpriteRenderer sprite;
    private Collider2D shadowCollider;
    private bool isInLight = false;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        shadowCollider = GetComponent<Collider2D>();

        sprite.enabled = false;
        shadowCollider.enabled = false;
    }

    void Update()
    {
        // Check if the real object is within the light's trigger area
        isInLight = lightTrigger != null && lightTrigger.OverlapPoint(realObject.position);

        // Always update position and scale based on real object and light
        Vector3 dir = realObject.position - lightSource.position;
        float distance = dir.magnitude;

        // Project shadow position away from the light
        Vector3 projectedPos = realObject.position + dir.normalized * offsetDistance;
        transform.position = projectedPos;

        // Adjust scale based on distance from light
        float newScale = 1f + distance * scaleMultiplier;
        transform.localScale = new Vector3(newScale, newScale, 1f);

        // Update visibility and collider status
        sprite.enabled = isInLight;
        shadowCollider.enabled = isInLight;
    }
}
