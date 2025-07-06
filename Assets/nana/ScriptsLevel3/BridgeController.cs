using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public GameObject bridge; // สะพาน GameObject (ลากใน Inspector)
    public PuzzleCollector puzzleCollector; // อ้างอิง PuzzleCollector ของผู้เล่น

    public int requiredPieces = 5; // จำนวนพัซเซิลที่ต้องเก็บให้ครบ

    private void Start()
    {
        if (bridge != null)
            bridge.SetActive(false); // ซ่อนสะพานตอนเริ่มเกม
    }

    private void Update()
    {
        if (puzzleCollector != null && puzzleCollector.numbersCollected >= requiredPieces)
        {
            if (!bridge.activeSelf)
            {
                bridge.SetActive(true); // เปิดสะพานเมื่อเก็บครบ
                Debug.Log("สะพานเปิดแล้ว!");
            }
        }
    }
}