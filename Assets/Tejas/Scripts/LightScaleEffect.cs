using UnityEngine;

public class LightScaleEffect : MonoBehaviour
{
    public Transform realObject;
    public Transform lightSource;
    public float minScale = 0.5f;
    public float maxScale = 2f;
    public float minDistance = 1f;
    public float maxDistance = 10f;

    void Update()
    {
        // Calculate distance between light and real object
        float distance = Vector2.Distance(lightSource.transform.position, realObject.position);
        // Normalize distance and invert for scale calculation
        float normalized = Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));
        float scale = Mathf.Lerp(maxScale, minScale, normalized);
        // Apply scale
        transform.localScale = new Vector3(scale, scale, 1);
    }
}