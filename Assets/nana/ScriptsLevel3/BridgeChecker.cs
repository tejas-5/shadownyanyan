using UnityEngine;

public class BridgeChecker : MonoBehaviour
{
    public GameObject bridge;

    void Start()
    {
        if (PlayerPrefs.GetInt("PuzzleCompleted", 0) == 1)
        {
            bridge.SetActive(true);
        }
    }
}

