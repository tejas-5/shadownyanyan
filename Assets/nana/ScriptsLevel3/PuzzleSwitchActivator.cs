using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PuzzleSwitchActivator : MonoBehaviour
{
    private bool playerInRange = false;
    public int requiredNumbers = 5;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // หาทุก Inventory ของ Player และ Shadow
            PlayerInventory[] inventories = FindObjectsOfType<PlayerInventory>();

            int totalCollected = inventories.Sum(inv => inv.CollectedCount());

            if (totalCollected >= requiredNumbers)
            {
                SceneManager.LoadScene("PuzzleScene");
            }
            else
            {
                Debug.Log("ยังเก็บตัวเลขไม่ครบ! เก็บแล้ว: " + totalCollected);
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