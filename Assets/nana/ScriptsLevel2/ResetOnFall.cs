using UnityEngine;

public class ResetOnFall : MonoBehaviour
{
    public Transform player;           // Player GameObject
    public Transform shadow;           // Shadow GameObject
    public Transform playerStartPoint; // จุดเริ่มต้นของ Player
    public Transform shadowStartPoint; // จุดเริ่มต้นของ Shadow

    public PlatformFadeOut eraser;
    public StartEraseTrigger eraseTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == player)
        {
            player.position = playerStartPoint.position;
            // Reset platforms and trigger
            eraser.ResetPlatforms();
            eraseTrigger.ResetTrigger();
        }
        else if (other.transform == shadow)
        {
            shadow.position = shadowStartPoint.position;
            // Reset platforms and trigger
            eraser.ResetPlatforms();
            eraseTrigger.ResetTrigger();
        }
    }
}