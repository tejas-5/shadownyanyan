using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueController : MonoBehaviour
{
    [Header("Bubble Prefabs")]
    public GameObject playerBubblePrefab;
    public GameObject shadowBubblePrefab;

    [Header("Speaker References")]
    public GameObject playerObject;
    public GameObject shadowObject;

    [Header("Text Position Offsets")]
    public Vector3 playerTextOffset = new Vector3(0, 2f, 0);
    public Vector3 shadowTextOffset = new Vector3(0, 2f, 0);

    [Header("UI Root")]
    public Canvas uiCanvas;   // ✅ assign Canvas หลักใน Inspector

    private List<DialogueLine> dialogues;
    private int currentIndex = 0;
    private bool isActive = false;

    private List<GameObject> activeBubbles = new List<GameObject>();

    void Update()
    {
        if (!isActive) return;

        if (Input.GetMouseButtonDown(0))
        {
            NextDialogue();
        }

        // อัพเดทตำแหน่ง Bubble ให้ตามตัวละคร
        foreach (var bubble in activeBubbles)
        {
            if (bubble == null) continue;

            var follow = bubble.GetComponent<DialogueBubble>();
            if (follow != null)
            {
                follow.UpdatePosition();
            }
        }
    }

    public void StartDialogue(List<DialogueLine> lines)
    {
        dialogues = lines;
        currentIndex = 0;
        isActive = true;
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
        // ลบ Bubble ก่อนหน้า
        foreach (var bubble in activeBubbles)
            if (bubble != null) Destroy(bubble);
        activeBubbles.Clear();

        DialogueLine currentLine = dialogues[currentIndex];

        if (currentLine.speaker == DialogueLine.Speaker.Player)
        {
            GameObject bubble = Instantiate(playerBubblePrefab, uiCanvas.transform); // ✅ ใต้ Canvas
            bubble.GetComponent<DialogueBubble>()
                .Initialize(playerObject, playerTextOffset, currentLine.text);
            activeBubbles.Add(bubble);
        }
        else
        {
            GameObject bubble = Instantiate(shadowBubblePrefab, uiCanvas.transform); // ✅ ใต้ Canvas
            bubble.GetComponent<DialogueBubble>()
                .Initialize(shadowObject, shadowTextOffset, currentLine.text);
            activeBubbles.Add(bubble);
        }
    }

    void EndDialogue()
    {
        foreach (var bubble in activeBubbles)
            if (bubble != null) Destroy(bubble);
        activeBubbles.Clear();

        isActive = false;
    }
}