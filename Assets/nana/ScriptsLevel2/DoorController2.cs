using UnityEngine;

public class DoorController2 : MonoBehaviour
{
    public GameObject doorVisual;
    public float moveDistance = 3f;
    public float moveSpeed = 2f;

    private bool isOpening = false;
    private Vector3 startPos;
    private Vector3 targetPos;

    private void Start()
    {
        if (doorVisual != null)
        {
            startPos = doorVisual.transform.position;
            targetPos = startPos + Vector3.up * moveDistance;
        }
    }

    private void Update()
    {
        if (!isOpening && KeyPickup2.shadowHasKey)
        {
            isOpening = true;
            Debug.Log("เปิดประตูเพราะ Shadow มีคีย์แล้ว!");
        }

        if (isOpening && doorVisual != null)
        {
            doorVisual.transform.position = Vector3.MoveTowards(
                doorVisual.transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
        }
    }
}