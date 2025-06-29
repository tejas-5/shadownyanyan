using UnityEngine;

public class SwingingPlatform : MonoBehaviour
{
    public float amplitude = 2f;
    public float speed = 2f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPos.x + offset, startPos.y, startPos.z);
    }
}