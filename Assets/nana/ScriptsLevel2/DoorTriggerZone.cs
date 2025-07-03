using UnityEngine;

public class DoorTriggerZone : MonoBehaviour
{
    public DoorController2 doorController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            doorController.TryOpenDoor();
        }
    }
}