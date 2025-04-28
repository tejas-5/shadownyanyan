using UnityEngine;

public class ToggleColliderBasedOnLayer : MonoBehaviour
{
    private Collider2D objectCollider;

    void Start()
    {
        // Get the Collider2D component attached to this GameObject
        objectCollider = GetComponent<Collider2D>();

        // Check the layer and enable/disable the collider accordingly
        if (objectCollider != null)
        {
            if (gameObject.layer == LayerMask.NameToLayer("Character1"))
            {
                objectCollider.enabled = false; // Disable collider for Character1
            }
            else if (gameObject.layer == LayerMask.NameToLayer("Character2"))
            {
                objectCollider.enabled = true;  // Enable collider for Character2
            }
        }
        else
        {
            Debug.LogWarning("Collider2D component not found on this GameObject.");
        }
    }
}
