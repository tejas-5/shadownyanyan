using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueController : MonoBehaviour
{
    [Header("Bubble Prefabs")]
    public GameObject playerBubblePrefab;
    public GameObject shadowBubblePrefab;

    [Header("UI Root")]
    public Canvas uiCanvas;

    private List<DialogueLine> dialogues;
    private int currentIndex = 0;
    private bool isActive = false;

    private GameObject currentPlayer;
    private GameObject currentShadow;

    private List<GameObject> activeBubbles = new List<GameObject>();

    // BubblePoint Transforms (บนตัวละคร)
    private Transform playerBubblePoint;
    private Transform shadowBubblePoint;

    void Update()
    {
        if (!isActive) return;

        if (Input.GetMouseButtonDown(0))
        {
            NextDialogue();
        }

        // อัพเดทตำแหน่ง Bubble
        for (int i = activeBubbles.Count - 1; i >= 0; i--)
        {
            GameObject bubble = activeBubbles[i];
            if (bubble == null)
            {
                activeBubbles.RemoveAt(i);
                continue;
            }

            DialogueBubble follow = bubble.GetComponent<DialogueBubble>();
            if (follow != null)
                follow.UpdatePosition();
        }
    }

    public void StartDialogue(List<DialogueLine> lines, GameObject player, GameObject shadow)
    {
        if (lines == null || lines.Count == 0)
        {
            Debug.LogWarning("No dialogues to start!");
            return;
        }

        if (uiCanvas == null)
        {
            Debug.LogError("UI Canvas is not assigned!");
            return;
        }

        EndDialogue(); // ลบ bubble เก่า

        dialogues = lines;
        currentIndex = 0;
        isActive = true;

        currentPlayer = player;
        currentShadow = shadow;

        // หา BubblePoint บนตัวละคร
        playerBubblePoint = currentPlayer.transform.Find("BubblePoint");
        shadowBubblePoint = currentShadow.transform.Find("BubblePoint");

        if (playerBubblePoint == null)
            Debug.LogWarning("Player does not have BubblePoint!");
        if (shadowBubblePoint == null)
            Debug.LogWarning("Shadow does not have BubblePoint!");

        ShowDialogue();
    }

    void NextDialogue()
    {
        currentIndex++;
        if (currentIndex < dialogues.Count)
            ShowDialogue();
        else
            EndDialogue();
    }

    void ShowDialogue()
    {
        if (dialogues == null || currentIndex >= dialogues.Count)
            return;

        DialogueLine currentLine = dialogues[currentIndex];

        // ลบ Bubble เก่า
        for (int i = activeBubbles.Count - 1; i >= 0; i--)
        {
            if (activeBubbles[i] != null)
                Destroy(activeBubbles[i]);
            activeBubbles.RemoveAt(i);
        }

        // เลือก prefab และ target
        GameObject prefab = null;
        Transform target = null;

        if (currentLine.speaker == DialogueLine.Speaker.Player)
        {
            prefab = playerBubblePrefab;
            target = playerBubblePoint;
        }
        else if (currentLine.speaker == DialogueLine.Speaker.Shadow)
        {
            prefab = shadowBubblePrefab;
            target = shadowBubblePoint;
        }

        // ตรวจสอบ null ปลอดภัย
        if (prefab == null || target == null)
        {
            Debug.LogError("Prefab or BubblePoint is null for speaker: " + currentLine.speaker);
            return;
        }

        // Instantiate Bubble
        GameObject newBubble = Instantiate(prefab, uiCanvas.transform);
        DialogueBubble bubbleScript = newBubble.GetComponent<DialogueBubble>();
        if (bubbleScript != null)
            bubbleScript.Initialize(target, currentLine.text);

        activeBubbles.Add(newBubble);
    }

    void EndDialogue()
    {
        for (int i = activeBubbles.Count - 1; i >= 0; i--)
        {
            if (activeBubbles[i] != null)
                Destroy(activeBubbles[i]);
        }
        activeBubbles.Clear();
        isActive = false;
    }
}