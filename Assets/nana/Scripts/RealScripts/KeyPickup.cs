using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public enum OwnerType { Player, Shadow }
    public OwnerType owner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (owner == OwnerType.Player && other.CompareTag("Player"))
        {
            Debug.Log("Player เก็บกุญแจ");
            KeyManager.instance.PickupKey(KeyManager.OwnerType.Player);  // เรียก enum จาก KeyManager
            Destroy(gameObject);
        }
        else if (owner == OwnerType.Shadow && other.CompareTag("Shadow"))
        {
            Debug.Log("Shadow เก็บกุญแจ");
            KeyManager.instance.PickupKey(KeyManager.OwnerType.Shadow);  // เรียก enum จาก KeyManager
            Destroy(gameObject);
        }
    }
}


