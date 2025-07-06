using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Image image;

    public Transform originalParent;
    private Vector3 originalScale;
    public Vector3 dragScale = new Vector3(1.2f, 1.2f, 1f);

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        image = GetComponent<Image>();

        originalScale = transform.localScale;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(canvas.transform);
        canvasGroup.blocksRaycasts = false;

        // ขยายขนาดและเปลี่ยนสี
        transform.localScale = dragScale;
        if (image != null)
        {
            image.color = Color.yellow;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // คืนขนาดและสีเดิม
        transform.localScale = originalScale;
        if (image != null)
        {
            image.color = Color.white;
        }

        if (transform.parent == canvas.transform)
        {
            // วางไม่สำเร็จ → กลับที่เดิม
            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = Vector2.zero;
        }
        else
        {
            // วางสำเร็จ เพิ่มเอฟเฟกต์เด้ง
            StartCoroutine(ScaleBounceEffect());
            Debug.Log("วางสำเร็จ!");
        }
    }

    private IEnumerator ScaleBounceEffect()
    {
        Vector3 original = transform.localScale;
        Vector3 bigger = original * 1.3f;

        float t = 0f;
        while (t < 0.2f)
        {
            transform.localScale = Vector3.Lerp(original, bigger, t / 0.2f);
            t += Time.deltaTime;
            yield return null;
        }
        t = 0f;
        while (t < 0.2f)
        {
            transform.localScale = Vector3.Lerp(bigger, original, t / 0.2f);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localScale = original;
    }


}
