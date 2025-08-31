using UnityEngine;

public class NumberPickup : MonoBehaviour
{
    public Sprite numberSprite; // Sprite ของตัวเลข / PuzzlePiece

    private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;

        // ให้ Player + Shadow เก็บได้
        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        {
            PlayerNumberHolder holder = other.GetComponent<PlayerNumberHolder>();
            if (holder != null)
            {
                holder.AddNumber(numberSprite);
                isCollected = true;

                // ซ่อนตัวเลข / PuzzlePiece
                gameObject.SetActive(false);
            }
        }
    }
}