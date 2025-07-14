using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("ติดลิฟต์แล้ว");
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("ออกจากลิฟต์แล้ว");
            collision.transform.SetParent(null);
        }
    }
}