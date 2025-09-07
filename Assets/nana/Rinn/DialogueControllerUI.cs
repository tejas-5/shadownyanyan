using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueControllerUI : MonoBehaviour
{
    private List<DialogueLine> dialogues;
    private int currentIndex = 0;

    public Transform playerPoint;
    public Transform shadowPoint;
    public TextMeshProUGUI dialogueText;
    public Vector3 offset = new Vector3(0, 2f, 0);
    private Transform currentTarget;

    // ฟังก์ชันให้ Trigger เรียก
    public void StartDialogue(List<DialogueLine> lines)
    {
        dialogues = lines;
        currentIndex = 0;
        ShowDialogue();
    }

    void Update()
    {
        // ป้องกัน Null
        if (dialogues == null || dialogues.Count == 0)
            return;

        if (Input.GetMouseButtonDown(0))
            NextDialogue();

        if (dialogueText != null && currentTarget != null)
            dialogueText.transform.position = Camera.main.WorldToScreenPoint(currentTarget.position + offset);
    }

    void NextDialogue()
    {
        if (dialogues == null || dialogues.Count == 0) return;

        currentIndex++;
        if (currentIndex < dialogues.Count)
            ShowDialogue();
        else
            EndDialogue();
    }

    void ShowDialogue()
    {
        if (dialogues == null || dialogues.Count == 0) return;

        DialogueLine line = dialogues[currentIndex];
        currentTarget = (line.speaker == Speaker.Player) ? playerPoint : shadowPoint;

        if (dialogueText != null)
            dialogueText.text = line.text;
    }

    void EndDialogue()
    {
        if (dialogueText != null)
            dialogueText.text = "";
        dialogues = null;
        currentIndex = 0;
    }
}