using UnityEngine;
using System.Collections.Generic;
using TMPro; // ต้องใช้ถ้าใช้ TextMeshPro

public enum Speaker { Player, Shadow }

[System.Serializable]
public class DialogueLine
{
    public Speaker speaker;
    [TextArea] public string text;
}

public class DialogueController : MonoBehaviour
{
    public Transform playerBubblePoint;
    public Transform shadowBubblePoint;
    public TextMeshProUGUI dialogueText; // Text UI ลอยบนหัว
    public Vector3 offset = new Vector3(0, 2f, 0);

    private List<DialogueLine> dialogues;
    private int currentIndex = 0;
    private Transform currentTarget; // ตัวละครที่กำลังพูด

    public void StartDialogue(List<DialogueLine> lines)
    {
        dialogues = lines;
        currentIndex = 0;
        ShowDialogue();
    }

    void Update()
    {
        if (dialogues == null || dialogues.Count == 0)
            return;

        if (dialogueText != null && currentTarget != null)
            dialogueText.transform.position = Camera.main.WorldToScreenPoint(currentTarget.position + offset);

        if (Input.GetMouseButtonDown(0))
            NextDialogue();
    }

    void NextDialogue()
    {
        if (dialogues == null || dialogues.Count == 0)
            return;

        currentIndex++;
        if (currentIndex < dialogues.Count)
            ShowDialogue();
        else
            EndDialogue();
    }

    void ShowDialogue()
    {
        if (dialogues == null || dialogues.Count == 0)
            return;

        DialogueLine line = dialogues[currentIndex];
        currentTarget = (line.speaker == Speaker.Player) ? playerBubblePoint : shadowBubblePoint;

        if (dialogueText != null)
            dialogueText.text = line.text;

        Debug.Log($"[{line.speaker}]: {line.text}");
    }

    void EndDialogue()
    {
        if (dialogueText != null)
            dialogueText.text = "";

        dialogues = null;
        currentIndex = 0;

        Debug.Log("Dialogue ended.");
    }
}