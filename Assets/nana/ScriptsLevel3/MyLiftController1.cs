using UnityEngine;
using UnityEngine.SceneManagement;

public class MyLiftController1 : MonoBehaviour
{
    
    [Header("ตั้งค่า Elevator")]
    public float speed = 2f;              // ความเร็วลิฟท์
    public float stopY = 5f;              // จุดสูงสุดที่ลิฟท์หยุด
    public string nextSceneName;          // ชื่อ Scene ถัดไป (ถ้าว่างจะไม่เปลี่ยน Scene)

    [Header("Trigger และ Key")]
    public Collider2D switchTrigger;      // พื้นที่ที่กดได้ (Trigger)
    public KeyCode activateKey = KeyCode.E;

    private bool isMoving = false;        // เช็คลิฟท์กำลังเคลื่อน
    private Transform player;             // ผู้เล่นที่เข้ามาในโซน

    void Update()
    {
        // ถ้า Player อยู่ใน trigger + กดปุ่ม → เริ่มลิฟท์
        if (player != null && Input.GetKeyDown(activateKey) && !isMoving)
        {
            isMoving = true;
        }

        // ถ้าลิฟท์กำลังเคลื่อน → ยกขึ้น
        if (isMoving)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            if (transform.position.y >= stopY)
            {
                isMoving = false;
                LoadNextScene();
            }
        }
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    // ตรวจจับว่า Player เข้ามาใน trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
        }
    }
}