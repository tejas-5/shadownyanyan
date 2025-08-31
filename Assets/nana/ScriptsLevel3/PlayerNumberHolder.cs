using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNumberHolder : MonoBehaviour
{
    [Header("UI Canvas & Container")]
    public Canvas numberCanvas;           // Canvas World Space บนหัว
    public RectTransform numberContainer; // Empty UI Object บน Canvas
    public float xSpacing = 30f;          // ระยะห่างระหว่างตัวเลข (UI Unit)

    private List<GameObject> collectedNumbers = new List<GameObject>();

    // เรียกตอนเก็บเลข / พัซเซิล
    public void AddNumber(Sprite numberSprite)
    {
        // สร้าง UI Image ของตัวเลข
        GameObject newNumber = new GameObject("NumberUI", typeof(Image));
        newNumber.transform.SetParent(numberContainer);
        newNumber.transform.localScale = Vector3.one;

        Image img = newNumber.GetComponent<Image>();
        img.sprite = numberSprite;

        collectedNumbers.Add(newNumber);

        RepositionNumbers();
    }

    private void RepositionNumbers()
    {
        for (int i = 0; i < collectedNumbers.Count; i++)
        {
            collectedNumbers[i].GetComponent<RectTransform>().anchoredPosition =
                new Vector2(i * xSpacing, 0f); // เรียงแนวนอน
        }
    }

    public int CollectedCount()
    {
        return collectedNumbers.Count;
    }
}