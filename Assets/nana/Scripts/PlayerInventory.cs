using System.Collections.Generic;
using UnityEngine;
public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> collectedPieces = new List<GameObject>();
    public void AddPuzzlePiece(GameObject piece)
    {
        collectedPieces.Add(piece);
        UpdatePiecePositions();
    }
    void UpdatePiecePositions()
    {
        for (int i = 0; i < collectedPieces.Count; i++)
        {
            GameObject piece = collectedPieces[i];
            Vector3 offset = new Vector3((i - collectedPieces.Count / 2f) * 0.8f, 1.5f, 0f);
            piece.transform.position = transform.position + offset;
        }
    }
    void Update()
    {
        UpdatePiecePositions(); // ให้ตามตัวทุกเฟรม
    }
}