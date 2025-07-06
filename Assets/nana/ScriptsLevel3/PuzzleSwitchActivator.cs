using UnityEngine;

public class PuzzleSwitchActivator : MonoBehaviour
{
    public GameObject puzzlePanel;
    public PuzzleGameManager puzzleManager;
    public float interactDistance = 2f;
    private Transform player, shadow;
    private PuzzleCollector pc, sc;

    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
        shadow = GameObject.FindWithTag("Shadow")?.transform;
        pc = player?.GetComponent<PuzzleCollector>();
        sc = shadow?.GetComponent<PuzzleCollector>();
        puzzlePanel?.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(transform.position, player.position) <= interactDistance)
        {
            int total = (pc?.numbersCollected ?? 0) + (sc?.numbersCollected ?? 0);
            if (total >= 5)
            {
                puzzleManager.ResetPuzzleNumbers();
                puzzlePanel.SetActive(true);
                Debug.Log("✅ Puzzle Panel Opened");
            }
            else Debug.Log($"❌ Need 5 pieces first (have {total})");
        }

        if (puzzlePanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            puzzlePanel.SetActive(false);
    }
}