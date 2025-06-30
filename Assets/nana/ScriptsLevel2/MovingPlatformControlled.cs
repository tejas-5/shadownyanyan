using UnityEngine;

public class MovingPlatformControlled : MonoBehaviour
{
    public float moveSpeed = 3f;
    private bool isMoving = false;
    private Vector3 targetPos;

    public void StartMoving(Vector3 destination)
    {
        isMoving = true;
        targetPos = destination;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                isMoving = false;
                StartCoroutine(DestroyAfterDelay(0.3f)); // รอ 0.3 วินาทีก่อนลบ
            }
        }
    }

    System.Collections.IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
