using UnityEngine;

public class Checkpoint2D : MonoBehaviour
{
    public static Vector2 lastCheckpointPosition;

    private void Start()
    {
        if (lastCheckpointPosition == Vector2.zero)
        {
            lastCheckpointPosition = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lastCheckpointPosition = transform.position;
            Debug.Log("チェックポイント更新: " + lastCheckpointPosition);
        }
    }
}
