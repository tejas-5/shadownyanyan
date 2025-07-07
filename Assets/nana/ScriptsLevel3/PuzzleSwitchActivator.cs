using UnityEngine;

public class PuzzleSwitchActivator : MonoBehaviour
{
    public GameObject puzzleCanvas;  // อ้างถึง Canvas ของ Puzzle

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            puzzleCanvas.SetActive(true); // เปิดพัซเซิล
            Time.timeScale = 0f; // หยุดเวลาเกม (หยุด Player)
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}