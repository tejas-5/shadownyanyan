using UnityEngine;

public class MovingPlatformInZone : MonoBehaviour
{
    public Transform pointA;      // Start point
    public Transform pointB;      // End point
    public float speed = 4f;      // Movement speed

    private Vector3 targetPos;

    private void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Please assign pointA and pointB in the inspector.");
            enabled = false;
            return;
        }
        transform.position = pointA.position;
        targetPos = pointB.position;
    }

    private void Update()
    {
        // Move towards the target point
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Switch target when reaching the current one
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            targetPos = targetPos == pointA.position ? pointB.position : pointA.position;
        }
    }
}