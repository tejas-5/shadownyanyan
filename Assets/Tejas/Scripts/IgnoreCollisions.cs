using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    public GameObject mainSquare; // Assign in Inspector
    public GameObject shadowSquare; // Assign in Inspector

    void Start()
    {
        Collider2D mainCollider = mainSquare.GetComponent<Collider2D>();
        Collider2D shadowCollider = shadowSquare.GetComponent<Collider2D>();

        if (mainCollider != null && shadowCollider != null)
        {
            Physics2D.IgnoreCollision(mainCollider, shadowCollider);
        }
    }
}