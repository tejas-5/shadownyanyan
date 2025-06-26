using UnityEngine;

public class ShadowPlatformController : MonoBehaviour
{
    private Collider2D shadowPlatformCollider;

    void Awake()
    {
        shadowPlatformCollider = GetComponent<Collider2D>();

        // หาผู้เล่นที่มี tag เป็น "Player" (หรือเปลี่ยนเป็น "RealPlayer" ถ้าคุณตั้งไว้แบบนั้น)
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");

        foreach (var player in allPlayers)
        {
            var playerCol = player.GetComponent<Collider2D>();
            if (playerCol != null)
            {
                // Ignore การชนระหว่างกล่องเงากับผู้เล่นตัวจริง
                Physics2D.IgnoreCollision(playerCol, shadowPlatformCollider, true);
            }
        }

        // ❌ ไม่ Ignore เงา (ShadowPlayer) เด็ดขาด — เงายังสามารถชนกับกล่องเงาได้
    }
}