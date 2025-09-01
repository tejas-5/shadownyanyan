using UnityEngine;

public class BridgeChecker : MonoBehaviour
{
    public GameObject bridge;

    void Start()
    {
        int completed = PlayerPrefs.GetInt("PuzzleCompleted", 0);
        Debug.Log("BridgeChecker: PuzzleCompleted = " + completed);

        bridge.SetActive(completed == 1);
    }
}