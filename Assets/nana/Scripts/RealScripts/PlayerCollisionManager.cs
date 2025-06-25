using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private Collider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        if (playerCollider == null)
        {
            Debug.LogError("PlayerCollisionManager: ไม่พบ Collider2D บนผู้เล่น");
            return;
        }

        // ใช้ FindObjectsByType แทน FindObjectsOfType (ใหม่และเร็วกว่า)
        ShadowPlatformController[] shadowPlatforms = FindObjectsByType<ShadowPlatformController>(FindObjectsSortMode.None);

        foreach (var sp in shadowPlatforms)
        {
            Collider2D shadowCollider = sp.GetComponent<Collider2D>();
            if (shadowCollider != null)
            {
                Physics2D.IgnoreCollision(playerCollider, shadowCollider, true);
            }
        }
    }
}
