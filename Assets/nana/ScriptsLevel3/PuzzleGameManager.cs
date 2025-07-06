using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{
    public GameObject slot1, slot2, slot3, slot4, slot5, bridgeToActivate;
    public Transform numberContainer;
    public GameObject puzzlePanel;

    public void OnCheckButtonPressed()
    {
        if (CheckPuzzleSolved())
        {
            bridgeToActivate?.SetActive(true);
            puzzlePanel.SetActive(false);
            Debug.Log("✅ Puzzle solved!");
        }
        else Debug.Log("❌ Puzzle not solved yet.");
    }

    private bool CheckPuzzleSolved()
    {
        GameObject[] slots = { slot1, slot2, slot3, slot4, slot5 };
        for (int i = 0; i < 5; i++)
        {
            if (slots[i].transform.childCount == 0) { Debug.Log($"Slot {i + 1} empty"); return false; }
            string num = slots[i].transform.GetChild(0).name;
            if (!num.StartsWith((i + 1).ToString())) { Debug.Log($"Slot {i + 1} wrong: {num}"); return false; }
        }
        return true;
    }

    public void ResetPuzzleNumbers()
    {
        GameObject[] slots = { slot1, slot2, slot3, slot4, slot5 };
        foreach (var slot in slots)
            if (slot.transform.childCount > 0)
            {
                var number = slot.transform.GetChild(0);
                number.SetParent(numberContainer);
                number.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
        Debug.Log("🧹 Reset complete");
    }
}