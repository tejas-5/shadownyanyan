using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShadowBoxFollower : MonoBehaviour
{
    public Transform realBox;               // RealBox ที่เงาจะตาม
    public List<Transform> lightSources;   // List of all light sources
    public float followHeight = 0f;         // ความสูงเหนือพื้นของกล่องเงา
    public Vector3 offset = new Vector3(1.5f, 0f, 0f);

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private BoxCollider2D col;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (sr != null)
            sr.enabled = false;
        if (col != null)
            col.enabled = false;
    }

    void LateUpdate()
    {
        if (realBox == null || lightSources == null || lightSources.Count == 0) return;

        // Get RealBox script and check if it's in light
        RealBox rbScript = realBox.GetComponent<RealBox>();
        bool shouldBeVisible = rbScript != null && rbScript.isInLight;

        if (!shouldBeVisible)
        {
            sr.enabled = false;
            if (col != null) col.enabled = false;
            return;
        }

        // Find closest light source to RealBox
        Transform closestLight = null;
        float closestDistance = Mathf.Infinity;
        Vector3 realPos = realBox.position;

        foreach (var light in lightSources)
        {
            float dist = Vector3.Distance(realPos, light.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestLight = light;
            }
        }

        if (closestLight != null)
        {
            // Compare x position of RealBox and closest light
            if (realBox.position.x > closestLight.position.x)
                offset.x = 1.5f;
            else
                offset.x = -1.5f; // or any smaller value you want
        }

        // Update shadow position
        float x = realBox.position.x + offset.x;
        float z = realBox.position.z + offset.z;
        float y = Mathf.Max(transform.position.y, realBox.position.y + followHeight);
        transform.position = new Vector3(x, y, z);

        // Enable shadow and collider
        sr.enabled = true;
        if (col != null)
            col.enabled = true;
    }
}
