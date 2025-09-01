using UnityEngine;

public class ShadowPlatformController : MonoBehaviour
{
    private Collider2D shadowPlatformCollider;

    void Awake()
    {
        shadowPlatformCollider = GetComponent<Collider2D>();

        if (shadowPlatformCollider == null)
        {
            Debug.LogWarning("❌ ไม่พบ Collider2D บน ShadowPlatform!");
            return;
        }

        // หา Player จริง แล้ว ignore collision ทันที
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            if (player.name.ToLower().Contains("shadow")) continue; // ข้าม Shadow

            Collider2D playerCol = player.GetComponent<Collider2D>();
            if (playerCol != null)
            {
                Physics2D.IgnoreCollision(playerCol, shadowPlatformCollider, true);
            }
        }

        // เริ่มแรก ปิด platform ไว้ก่อน (เหมือนไม่มีทางเดิน)
        shadowPlatformCollider.enabled = false;
    }

    // เรียกเมื่อมีไฟส่อง platform
    public void ActivatePlatform()
    {
        shadowPlatformCollider.enabled = true;
        Debug.Log("✨ Shadow Platform เปิดใช้งานเพราะไฟส่อง!");
    }

    // เรียกเมื่อไฟดับ
    public void DeactivatePlatform()
    {
        shadowPlatformCollider.enabled = false;
        Debug.Log("💤 Shadow Platform ปิดเพราะไม่มีไฟ!");
    }
}