using UnityEngine;

public class MovingPlatformBetweenPoints : MonoBehaviour
{
    public Transform pointA;    // จุดเริ่มต้น (ลาก GameObject ที่ต้องการใน Inspector)
    public Transform pointB;    // จุดปลายทาง
    public float speed = 2f;    // ความเร็วเคลื่อนที่

    private Vector3 targetPos;  // ตำแหน่งที่กำลังเคลื่อนที่ไป
    private Vector3 startPos;

    void Start()
    {
        startPos = pointA.position;  // เริ่มที่จุด A
        targetPos = pointB.position; // เคลื่อนที่ไป B ก่อน
        transform.position = startPos;
    }

    void Update()
    {
        // เคลื่อนที่ไปหาตำแหน่ง targetPos ด้วยความเร็วที่กำหนด
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // ถ้าไปถึง targetPos แล้ว ให้สลับเป้าหมาย
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            if (targetPos == pointB.position)
                targetPos = pointA.position;
            else
                targetPos = pointB.position;
        }
    }

    // ให้ผู้เล่น/เงาติดตามแพลตฟอร์ม
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Shadow"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Shadow"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
