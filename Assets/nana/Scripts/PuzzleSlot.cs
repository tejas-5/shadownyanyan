using UnityEngine;
using UnityEngine.EventSystems;
public class PuzzleSlot : MonoBehaviour, IDropHandler
{
    public int correctPieceIndex;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragged = eventData.pointerDrag;
        if (dragged != null)
        {
            PuzzlePieceData piece = dragged.GetComponent<PuzzlePieceData>();
            if (piece != null && piece.index == correctPieceIndex)
            {
                // ล็อกตำแหน่งไว้
                dragged.transform.position = transform.position;
                piece.locked = true;
                PuzzleChecker.Instance.CheckCompletion();
            }
        }
    }
}