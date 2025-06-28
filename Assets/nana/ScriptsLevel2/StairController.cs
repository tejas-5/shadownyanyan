using UnityEngine;

public class StairController : MonoBehaviour
{
    // ไม่ต้องใช้ isRealLadder เพราะใช้ Tag แยกแทน

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player == null) return;

        if (player.isRealPlayer && gameObject.CompareTag("RealLadder"))
        {
            player.EnableClimbing(true);
        }
        else if (!player.isRealPlayer && gameObject.CompareTag("ShadowLadder"))
        {
            player.EnableClimbing(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player == null) return;

        if ((player.isRealPlayer && gameObject.CompareTag("RealLadder")) ||
            (!player.isRealPlayer && gameObject.CompareTag("ShadowLadder")))
        {
            player.EnableClimbing(false);
        }
    }
}
