using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueController : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI shadowText;

    [Header("Speaker References")]
    public GameObject playerObject;
    public GameObject shadowObject;

    [Header("Text Position Offsets")]
    public Vector3 playerTextOffset = new Vector3(0, 2f, 0);   // editable in Inspector
    public Vector3 shadowTextOffset = new Vector3(0, 2f, 0);   // editable in Inspector

    private List<DialogueLine> dialogues;
    private int currentIndex = 0;
    private bool isActive = false;

    void Update()
    {
        if (isActive && Input.GetMouseButtonDown(0))
        {
            NextDialogue();
        }

        // Keep text following characters
        if (isActive)
        {
            UpdateTextPosition(playerText, playerObject, playerTextOffset);
            UpdateTextPosition(shadowText, shadowObject, shadowTextOffset);
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
        playerText.text = "";
        shadowText.text = "";

        DialogueLine currentLine = dialogues[currentIndex];

        if (currentLine.speaker == DialogueLine.Speaker.Player)
        {
            playerText.text = currentLine.text;
        }
        else
        {
            shadowText.text = currentLine.text;
        }
    }

    void EndDialogue()
    {
        playerText.text = "";
        shadowText.text = "";
        isActive = false;
    }

    void UpdateTextPosition(TextMeshProUGUI text, GameObject target, Vector3 offset)
    {
        if (string.IsNullOrEmpty(text.text)) return;

        // Convert world position → screen position with offset
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position + offset);
        text.transform.position = screenPos;
    }
}
