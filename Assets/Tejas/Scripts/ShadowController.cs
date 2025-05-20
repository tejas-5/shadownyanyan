using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ShadowController : MonoBehaviour
{
    [Header("References")]
    public Transform realObject;      // The ÅgrealÅh counterpart
    public Transform lightSource;     // Your PointLight transform

    [Header("Projection Settings")]
    [Tooltip("How much the shadow scales per unit distance.")]
    public float scaleMultiplier = 0.1f;
    [Tooltip("How far beyond the real object to push the shadow.")]
    public float offsetDistance = 0.5f;

    private SpriteRenderer sprite;
    private bool isInLight = false;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        // Optionally start hidden
        sprite.enabled = false;
    }

    // Called when entering the lightÅfs trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == lightSource.gameObject)
            isInLight = true;
    }

    // Called when exiting the lightÅfs trigger
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == lightSource.gameObject)
            isInLight = false;
    }

    void Update()
    {
        if (!isInLight)
        {
            sprite.enabled = false;
            return;
        }

        sprite.enabled = true;

        // 1) Direction from light to real object
        Vector3 dir = (realObject.position - lightSource.position);
        float distance = dir.magnitude;

        // 2) Position shadow slightly farther along that ray
        Vector3 projectedPos = realObject.position + dir.normalized * offsetDistance;
        transform.position = projectedPos;

        // 3) Scale shadow proportional to distance
        float newScale = 1f + distance * scaleMultiplier;
        transform.localScale = new Vector3(newScale, newScale, 1f);
    }
}
