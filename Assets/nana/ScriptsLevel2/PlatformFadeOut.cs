using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformFadeOut : MonoBehaviour
{
    public List<GameObject> platformPieces;
    public float fadeDuration = 1f;
    public float delayBetweenPieces = 0.3f;
    public float initialDelayBeforeErase = 1.0f;

    private bool isErasing = false;

    public void StartErasing()
    {
        if (!isErasing)
        {
            isErasing = true;
            StartCoroutine(FadeOutPlatforms());
        }
    }

    private IEnumerator FadeOutPlatforms()
    {
        yield return new WaitForSeconds(initialDelayBeforeErase);

        var sorted = platformPieces
            .Where(p => p != null)
            .OrderBy(p => p.transform.position.x)
            .ToList();

        // คำนวณ delay อัตโนมัติให้ใช้เวลารวม ~30 วินาที
        int pieceCount = sorted.Count;
        if (pieceCount > 1)
        {
            delayBetweenPieces = (15f - fadeDuration) / (pieceCount - 1);
        }

        foreach (GameObject piece in sorted)
        {
            StartCoroutine(FadeOutPiece(piece));
            yield return new WaitForSeconds(delayBetweenPieces);
        }
    }

    private IEnumerator FadeOutPiece(GameObject piece)
    {
        SpriteRenderer sr = piece.GetComponent<SpriteRenderer>();
        Collider2D col = piece.GetComponent<Collider2D>();

        if (sr != null)
        {
            Color originalColor = sr.color;
            float t = 0f;

            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
                sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                yield return null;
            }
        }

        // ปิด Collider หลังจากจางหมดแล้ว
        if (col != null) col.enabled = false;

        piece.SetActive(false); // หรือ Destroy(piece);
    }

    // ✅ เพิ่มฟังก์ชัน Reset ให้เรียกสร้าง Platform ใหม่
    public void ResetPlatforms()
    {
        foreach (GameObject piece in platformPieces)
        {
            if (piece == null) continue;

            SpriteRenderer sr = piece.GetComponent<SpriteRenderer>();
            Collider2D col = piece.GetComponent<Collider2D>();

            if (sr != null)
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);

            if (col != null)
                col.enabled = true;

            piece.SetActive(true);
        }

        isErasing = false;
    }
}