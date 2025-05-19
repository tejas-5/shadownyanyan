using UnityEngine;

public class LightScaleEffect : MonoBehaviour
{
    public Transform lightSource; // Reference to the light source
    public float maxDistance = 5f; // Maximum distance for scaling effect
    public float minScale = 0.5f; // Minimum scale factor
    public float maxScale = 2f; // Maximum scale factor
    void Update()
    {

        
        // Calculate the distance between the object and the light source
        float distance = Vector2.Distance(transform.position, lightSource.position);

        // Normalize the distance to a value between 0 and 1
        float normalizedDistance = Mathf.InverseLerp(0, maxDistance, distance);

        // Calculate the scale factor based on the distance
        float scaleFactor = Mathf.Lerp(maxScale, minScale, normalizedDistance);

        // Apply the new scale to the object
        transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
        
    }
}
