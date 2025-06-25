using UnityEngine;

public class LiftController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    private int currentWaypoint = 0;
    private bool isActive = false; // สถานะลิฟต์

    void FixedUpdate()
    {
        if (!isActive) return; // หยุดทำงานถ้าลิฟต์ปิด

        // เคลื่อนที่ไปยัง waypoint
        Vector2 targetPos = waypoints[currentWaypoint].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);

        // เปลี่ยนจุดหมายเมื่อถึง
        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

    // เมธอดสำหรับเปิด/ปิดลิฟต์
    public void Toggle()
    {
        isActive = !isActive;
        Debug.Log(isActive ? "ลิฟต์เปิดทำงาน" : "ลิฟต์ปิดแล้ว");
    }

    // ทำให้ผู้เล่นเคลื่อนที่ไปกับลิฟต์
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
