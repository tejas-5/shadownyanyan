using UnityEngine;

public class StartEraseTrigger : MonoBehaviour
{
    public PlatformFadeOut eraser;
    public Transform player;

    [HideInInspector] public bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.transform == player)
        {
            triggered = true;
            eraser.StartErasing();
        }
    }

    // Called when player respawns to make the trigger usable again
    public void ResetTrigger()
    {
        triggered = false;
    }
}
