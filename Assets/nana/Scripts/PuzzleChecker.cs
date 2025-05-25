using UnityEngine;
public class PuzzleChecker : MonoBehaviour
{
    public static PuzzleChecker Instance;
    public PuzzlePieceData[] pieces;
    public GameObject completeImage; // แสดงเมื่อเสร็จ
    private void Awake()
    {
        Instance = this;
    }
    public void CheckCompletion()
    {
        foreach (var p in pieces)
        {
            if (!p.locked)
                return;
        }
        Debug.Log("พัซเซิลเสร็จแล้ว!");
        completeImage.SetActive(true);
    }
}
