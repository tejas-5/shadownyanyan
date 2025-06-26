using UnityEngine;

public class WaterDropTrigger : MonoBehaviour
{
    public Transform playerStartPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = playerStartPoint.position;
            Debug.Log("Player hit water drop! Respawn to start.");
        }
    }
}