using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI shadowText;

    public GameObject playerObject;    // <-- Assign in Inspector
    public GameObject shadowObject;    // <-- Assign in Inspector

    private List<DialogueLine> dialogues;
    private int currentIndex = 0;
    private bool isActive = false;

    void Update()
    {
        if (isActive && Input.GetMouseButtonDown(0))
        {
            NextDialogue();
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
            FocusOn(playerObject);
        }
        else
        {
            shadowText.text = currentLine.text;
            FocusOn(shadowObject);
        }
    }

    void EndDialogue()
    {
        playerText.text = "";
        shadowText.text = "";
        isActive = false;

        // Optional: Reset camera or focus
    }

    void FocusOn(GameObject target)
    {

        // Example 2: If using Cinemachine or camera focus:
        // cameraFollow.target = target.transform;
    }
}
