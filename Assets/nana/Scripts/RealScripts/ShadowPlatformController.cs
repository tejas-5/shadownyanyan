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

        // หาเฉพาะผู้เล่นตัวจริงเท่านั้น (เช่น tag = "Player")
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            // ตรวจสอบว่าไม่ใช่เงา
            if (player.name.ToLower().Contains("shadow")) continue;

            Collider2D playerCol = player.GetComponent<Collider2D>();
            if (playerCol != null)
            {
                Physics2D.IgnoreCollision(playerCol, shadowPlatformCollider, true);
            }
        }

        // ✅ ไม่ ignore กับ ShadowPlayer — เงายังสามารถยืนบน platform ได้
    }
}