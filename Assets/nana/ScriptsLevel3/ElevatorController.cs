using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    private int currentWaypoint = 0;
    private bool isActive = false;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // เพิ่มตรงนี้
    }

    void FixedUpdate()
    {
        if (!isActive) return;

        Vector2 targetPos = waypoints[currentWaypoint].position;
        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPos, speed * Time.fixedDeltaTime));

        if (Vector2.Distance(rb.position, targetPos) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

    public void Toggle()
    {
        isActive = !isActive;
        Debug.Log(isActive ? "ลิฟต์เปิดทำงาน" : "ลิฟต์ปิดแล้ว");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ผู้เล่นติดลิฟต์");
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ผู้เล่นออกจากลิฟต์");
            collision.transform.SetParent(null);
        }
    }
}