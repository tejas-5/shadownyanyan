using UnityEngine;

public class WaterDropMovement : MonoBehaviour
{
    public float fallSpeed = 4f;
    public float resetY = -4.06f;
    public float startY = 7.6f;

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (transform.position.y <= resetY)
        {
            transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        }
    }
}