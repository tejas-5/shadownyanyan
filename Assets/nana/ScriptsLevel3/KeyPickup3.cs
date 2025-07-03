using UnityEngine;

public class KeyPickup3 : MonoBehaviour
{
    public GameObject targetToUnlock; // กล่องหรือประตู

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("เก็บกุญแจแล้ว!");
            Destroy(gameObject); // ลบกุญแจ

            if (targetToUnlock != null)
            {
                Destroy(targetToUnlock); // ลบกล่องออกจากฉาก
            }
        }
    }
}
