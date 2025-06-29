using UnityEngine;

public class SpotlightMover : MonoBehaviour
{
    public float moveAmplitude = 4f; // ระยะทางแกว่งซ้าย-ขวา
    public float moveSpeed = 2f;     // ความเร็วการแกว่ง

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float xOffset = Mathf.Sin(Time.time * moveSpeed) * moveAmplitude;
        transform.position = new Vector3(startPos.x + xOffset, startPos.y, startPos.z);
    }
}