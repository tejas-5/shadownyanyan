using UnityEngine;

public class FallResetManager : MonoBehaviour
{
    public Transform player;
    public Transform shadow;
    public Transform startPoint;
    public float fallYThreshold = -10f;

    void Update()
    {
        if (player.position.y < fallYThreshold || shadow.position.y < fallYThreshold)
        {
            ResetPositions();
        }
    }

    void ResetPositions()
    {
        Debug.Log("????????? ???????????????!");

        player.position = startPoint.position;
        shadow.position = startPoint.position;

        // Reset velocity ???? ?????? Rigidbody2D
        if (player.TryGetComponent<Rigidbody2D>(out var rb1)) rb1.linearVelocity = Vector2.zero;
        if (shadow.TryGetComponent<Rigidbody2D>(out var rb2)) rb2.linearVelocity = Vector2.zero;
    }
}
