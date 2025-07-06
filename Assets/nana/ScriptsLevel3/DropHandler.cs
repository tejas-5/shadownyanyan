using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped != null)
        {
            dropped.transform.SetParent(transform); // move into slot
            dropped.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            Debug.Log($"✅ วาง {dropped.name} ลง {gameObject.name} แล้ว");
        }
    }
}