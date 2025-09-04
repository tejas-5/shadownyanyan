using UnityEngine;
using TMPro;

public class DialogueBubble : MonoBehaviour
{
    private GameObject target;
    private Vector3 offset;
    private RectTransform rect;
    private TextMeshProUGUI textComponent;
    private Canvas parentCanvas;

    public void Initialize(GameObject target, Vector3 offset, string text)
    {
        this.target = target;
        this.offset = offset;

        rect = GetComponent<RectTransform>();
        textComponent = GetComponentInChildren<TextMeshProUGUI>();
        textComponent.text = text;

        parentCanvas = GetComponentInParent<Canvas>();

        UpdatePosition();
    }

    public void UpdatePosition()
    {
        if (target == null || parentCanvas == null) return;

        // World position + offset (เช่นตรงหัวตัวละคร)
        Vector3 worldPos = target.transform.position + offset;

        // ใช้กล้องของ Canvas (สำคัญมากถ้า Canvas ไม่ใช่ Overlay)
        Camera cam = parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay 
            ? null 
            : parentCanvas.worldCamera;

        // World → Local Position (ภายใน Canvas)
        RectTransform canvasRect = parentCanvas.GetComponent<RectTransform>();
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            RectTransformUtility.WorldToScreenPoint(cam, worldPos),
            cam,
            out localPos
        );

        rect.localPosition = localPos;
    }
}
