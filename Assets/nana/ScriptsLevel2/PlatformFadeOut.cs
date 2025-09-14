using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            Debug.Log("▶ PlatformFadeOut: StartErasing called!");
            isErasing = true;
            StartCoroutine(FadeOutPlatforms());
        }
        else
        {
            Debug.Log("⚠ PlatformFadeOut: Already erasing, ignored.");
        }
    }

    private IEnumerator FadeOutPlatforms()
    {
        yield return new WaitForSeconds(initialDelayBeforeErase);

        var sorted = platformPieces
            .Where(p => p != null)
            .OrderBy(p => p.transform.position.x)
            .ToList();

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

        // ✅ erasing จบแล้ว
        isErasing = false;
        Debug.Log("✅ PlatformFadeOut: Finished erasing all pieces");
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

        if (col != null) col.enabled = false;
        piece.SetActive(false);
        Debug.Log($"❌ Piece disabled: {piece.name}");
    }

    public void ResetPlatforms()
    {
        StopAllCoroutines();
        isErasing = false;

        foreach (GameObject piece in platformPieces)
        {
            if (piece == null) continue;

            piece.SetActive(true);

            SpriteRenderer sr = piece.GetComponent<SpriteRenderer>();
            Collider2D col = piece.GetComponent<Collider2D>();

            if (sr != null)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
            if (col != null)
            {
                col.enabled = true;
            }

            Debug.Log($"✅ Reset piece: {piece.name}");
        }
    }
}