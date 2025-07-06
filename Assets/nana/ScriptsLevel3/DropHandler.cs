using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped != null)
        {
            dropped.transform.SetParent(transform);
            dropped.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            Debug.Log("✅ วาง " + dropped.name + " ลง " + gameObject.name + " แล้ว");

            // Debug Parent
            Debug.Log("📍 Parent ของ " + dropped.name + " คือ: " + dropped.transform.parent.name);
        }
    }
}