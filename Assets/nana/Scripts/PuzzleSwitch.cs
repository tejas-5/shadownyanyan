using UnityEngine;
public class PuzzleSwitch : MonoBehaviour
{
    public GameObject puzzleUI;
    public PuzzleCollector puzzleCollector; // <-- ต้องเชื่อมกับระบบเก็บพัซเซิล
    private bool playerInRange;
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (puzzleCollector.collectedPieces.Count >= 3)
            {
                puzzleUI.SetActive(true); // แสดง UI เมื่อครบ 3 ชิ้น
            }
            else
            {
                Debug.Log("คุณยังเก็บพัซเซิลไม่ครบ!");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}