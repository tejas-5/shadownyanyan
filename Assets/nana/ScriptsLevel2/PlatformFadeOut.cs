using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformFadeOut : MonoBehaviour
{
    public List<GameObject> platformPieces;
    public Transform player;
    public float checkInterval = 0.4f;
    public float fadeDuration = 1f;

    private List<GameObject> fadedPieces = new List<GameObject>();
    private bool isErasing = false;

    // เรียกจาก trigger
    public void StartErasing()
    {
        if (!isErasing)
        {
            StartCoroutine(CheckAndFade());
        }
    }

    private IEnumerator CheckAndFade()
    {
        isErasing = true;

        while (true)
        {
            foreach (GameObject piece in platformPieces)
            {
                if (piece == null || fadedPieces.Contains(piece)) continue;

                // ถ้าชิ้นนี้อยู่ "ด้านหลัง" player
                if (piece.transform.position.x < player.position.x - 0.1f)
                {
                    fadedPieces.Add(piece);
                    StartCoroutine(FadeOutPiece(piece));
                }
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }

    private IEnumerator FadeOutPiece(GameObject piece)
    {
        SpriteRenderer sr = piece.GetComponent<SpriteRenderer>();
        Collider2D col = piece.GetComponent<Collider2D>();

        if (col != null) col.enabled = false;

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

        piece.SetActive(false); // หรือ Destroy(piece);
    }
}