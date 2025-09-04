using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> collectedPieces = new List<GameObject>();
    public Transform holdPoint; // จุดอ้างอิง (ตั้ง empty GameObject ไว้บน Player)

    public void AddPuzzlePiece(GameObject piece)
    {
        if (collectedPieces.Contains(piece)) return;

        collectedPieces.Add(piece);

        // ปิดการชน
        if (piece.TryGetComponent<Collider2D>(out var col))
            Destroy(col);
        if (piece.TryGetComponent<Rigidbody2D>(out var rb))
            Destroy(rb);

        // ทำให้เป็นลูกของ Player (หรือ holdPoint)
        piece.transform.SetParent(holdPoint != null ? holdPoint : transform);

        UpdatePiecePositions();
    }

    void UpdatePiecePositions()
    {
        // ปรับให้สัมพันธ์กับความกว้าง sprite
        float spacing = 2.3f; // ลองเริ่มที่ 1.2 หรือ 1.5 ดู (ใหญ่กว่ากว้างจริงนิดหน่อย)
        float startX = -(collectedPieces.Count - 1) * spacing / 2f;

        for (int i = 0; i < collectedPieces.Count; i++)
        {
            GameObject piece = collectedPieces[i];
            Vector3 offset = new Vector3(startX + i * spacing, 1.5f, 0f);
            piece.transform.localPosition = offset;
        }
    }

    void Update()
    {
        UpdatePiecePositions();
    }

    // ✅ ใช้เช็คกับ PuzzleSwitchActivator
    public int CollectedCount()
    {
        return collectedPieces.Count;
    }
}