using UnityEngine;

public class StartEraseTrigger : MonoBehaviour
{
    public PlatformFadeOut eraser;
    public Transform player;

    [HideInInspector] public bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"🚪 StartEraseTrigger: OnTriggerEnter with {other.name}");

        if (!triggered && other.transform == player)
        {
            triggered = true;
            Debug.Log("▶ StartEraseTrigger: Triggered, start erasing!");
            eraser.StartErasing();
        }
        else if (triggered)
        {
            Debug.Log("⚠ StartEraseTrigger: Already triggered, ignoring.");
        }
    }

    public void ResetTrigger()
    {
        triggered = false;
        Debug.Log("🔄 StartEraseTrigger: ResetTrigger called!");
    }
}