using UnityEngine;

public class KeyPickup2 : MonoBehaviour
{
    public static bool shadowHasKey = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            shadowHasKey = true;
            Debug.Log("Shadow ได้กุญแจแล้ว!");
            Destroy(gameObject); // ทำลายกุญแจเมื่อเก็บ
        }
    }
}