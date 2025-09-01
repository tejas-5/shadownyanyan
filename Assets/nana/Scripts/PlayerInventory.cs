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
        for (int i = 0; i < collectedPieces.Count; i++)
        {
            GameObject piece = collectedPieces[i];
            Vector3 offset = new Vector3((i - collectedPieces.Count / 2f) * 0.8f, 1.5f, 0f);

            // ใช้ localPosition ให้มันจัดเรียงรอบ Player
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