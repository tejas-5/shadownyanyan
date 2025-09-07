using UnityEngine;
using TMPro;

public class DialogueBubble : MonoBehaviour
{
    private Transform targetTransform;      // จุดอ้างอิง BubblePoint
    private RectTransform rect;             // RectTransform ของ Bubble
    private TextMeshProUGUI textComponent;  // Text ของ Bubble
    private Canvas parentCanvas;            // Canvas ที่ Bubble อยู่

    /// <summary>
    /// เริ่มต้น Bubble
    /// </summary>
    /// <param name="target">Transform ของ BubblePoint</param>
    /// <param name="text">ข้อความที่จะแสดง</param>
    public void Initialize(Transform target, string text)
    {
        if (target == null)
        {
            Debug.LogError("DialogueBubble: Target is null!");
            return;
        }

        targetTransform = target;

        rect = GetComponent<RectTransform>();
        textComponent = GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
            textComponent.text = text;
        else
            Debug.LogWarning("DialogueBubble: No TextMeshProUGUI found!");

        parentCanvas = GetComponentInParent<Canvas>();
        if (parentCanvas == null)
            Debug.LogError("DialogueBubble: No parent Canvas found!");

        UpdatePosition();
    }

    /// <summary>
    /// อัพเดทตำแหน่ง Bubble ให้ตาม BubblePoint
    /// </summary>
    public void UpdatePosition()
    {
        if (targetTransform == null || parentCanvas == null || rect == null)
            return;

        Vector3 worldPos = targetTransform.position;

        if (parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            // Overlay → ใช้ ScreenPoint ตรง ๆ
            rect.position = RectTransformUtility.WorldToScreenPoint(null, worldPos);
        }
        else
        {
            // ScreenSpace Camera หรือ World Space → แปลงเป็น local ของ Canvas
            Vector2 localPos;
            RectTransform canvasRect = parentCanvas.GetComponent<RectTransform>();
            Camera cam = parentCanvas.worldCamera;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                RectTransformUtility.WorldToScreenPoint(cam, worldPos),
                cam,
                out localPos
            );
            rect.localPosition = localPos;
        }
    }
}