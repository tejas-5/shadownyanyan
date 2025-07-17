using UnityEngine;
using System.Collections;

public class ElevatorPlatform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform); // ติดลิฟต์
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DetachAfterFrame(collision.transform)); // ถอดหลังจาก 1 เฟรม
        }
    }

    IEnumerator DetachAfterFrame(Transform player)
    {
        yield return null; // ป้องกัน error จากการ set active
        player.SetParent(null);
    }

}