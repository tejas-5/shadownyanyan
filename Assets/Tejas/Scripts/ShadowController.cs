using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class ShadowController : MonoBehaviour
{
    [Header("References")]
    public Transform realObject;   
    public Transform lightSource;    
    public Collider2D lightTrigger;  

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
        isInLight = lightTrigger != null && lightTrigger.OverlapPoint(realObject.position);

        Vector3 dir = realObject.position - lightSource.position;
        float distance = dir.magnitude;

        Vector3 projectedPos = realObject.position + dir.normalized * offsetDistance;
        transform.position = projectedPos;

        float newScale = 1f + distance * scaleMultiplier;
        transform.localScale = new Vector3(newScale, newScale, 1f);

        sprite.enabled = isInLight;
        shadowCollider.enabled = isInLight;
    }
}
