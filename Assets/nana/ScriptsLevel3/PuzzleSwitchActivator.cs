using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleSwitchActivator : MonoBehaviour
{
    private bool playerInRange = false;

    // กำหนดว่าต้องเก็บครบกี่แผ่น
    public int requiredNumbers = 5;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // เช็คว่าผู้เล่นเก็บครบหรือยัง
            PlayerNumberHolder holder = FindObjectOfType<PlayerNumberHolder>();
            if (holder != null && holder.CollectedCount() >= requiredNumbers)
            {
                SceneManager.LoadScene("PuzzleScene");
            }
            else
            {
                Debug.Log("ยังเก็บตัวเลขไม่ครบ!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
            playerInRange = false;
    }
}