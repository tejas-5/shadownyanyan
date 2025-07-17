using UnityEngine;

public class MyLiftController : MonoBehaviour
{
    public float speed = 2f;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    public void ActivateLift()
    {
        isMoving = true;
    }
}