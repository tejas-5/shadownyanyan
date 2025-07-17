using UnityEngine;

public class PuzzleReset : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("PuzzleCompleted", 0);
        PlayerPrefs.Save();
        Debug.Log("🔄 PuzzleCompleted reset to 0");
    }
}