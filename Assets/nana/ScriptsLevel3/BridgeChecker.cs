using UnityEngine;

public class BridgeChecker : MonoBehaviour
{
    public GameObject bridge;

    void Start()
    {
        bool completed = GameManager.Instance != null && GameManager.Instance.puzzleCompleted;
        Debug.Log("BridgeChecker: PuzzleCompleted = " + completed);

        bridge.SetActive(completed);
    }
}