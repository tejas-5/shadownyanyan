using UnityEngine;
public class PuzzlePiece : MonoBehaviour
{
    private bool isCollected = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;
        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        {
            isCollected = true;
            // ปิดการชนไม่ให้ชนซ้ำ
            GetComponent<Collider2D>().enabled = false;
            // ถ้ามี Rigidbody2D ก็ลบทิ้ง
            if (TryGetComponent<Rigidbody2D>(out var rb))
                Destroy(rb);
            // เพิ่มพัซเซิลให้ Player
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddPuzzlePiece(gameObject);
            }
        }
    }
}
