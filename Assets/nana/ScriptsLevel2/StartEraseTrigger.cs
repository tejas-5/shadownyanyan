using UnityEngine;

public class StartEraseTrigger : MonoBehaviour
{
    public PlatformFadeOut eraser;
    public Transform player;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.transform == player)
        {
            triggered = true;
            eraser.StartErasing();
        }
    }
}