using UnityEngine;

public class PuzzleCollector : MonoBehaviour
{
    public int numbersCollected = 0;

    public bool HasAllNumbers()
    {
        return numbersCollected >= 5;
    }
}