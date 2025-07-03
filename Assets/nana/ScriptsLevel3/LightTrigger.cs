using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightTrigger : MonoBehaviour
{
    public GameObject lightPath;    // ลาก LightPath มาที่นี่จาก Inspector
    public Rigidbody2D boxRb;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lightPath.SetActive(true);                   // เปิดเส้นไฟให้เงาเดินได้
            boxRb.bodyType = RigidbodyType2D.Kinematic; // หยุดไม่ให้กล่องเคลื่อน
            boxRb.linearVelocity = Vector2.zero;              // หยุดความเร็วของกล่อง
        }
    }
}