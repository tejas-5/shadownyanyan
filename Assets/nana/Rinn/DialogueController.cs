using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI shadowText;

    private List<DialogueLine> dialogues;
    private int currentIndex = 0;
    private bool isActive = false;

    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.Space))
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

        if (dialogues[currentIndex].speaker == DialogueLine.Speaker.Player)
            playerText.text = dialogues[currentIndex].text;
        else
            shadowText.text = dialogues[currentIndex].text;
    }

    void EndDialogue()
    {
        playerText.text = "";
        shadowText.text = "";
        isActive = false;
    }
}