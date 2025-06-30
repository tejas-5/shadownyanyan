using UnityEngine;

public class PlayerPlatformAttach : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ถ้าแตะพื้นที่ชื่อมีคำว่า "Platform"
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(collision.transform);  // ทำให้เป็นลูกของพื้น
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // เมื่อออกจากพื้น
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);  // ปลด parent ออก
        }
    }
}
