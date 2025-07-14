using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBubblePrefab;

    private Queue<DialogueLine> dialogueQueue = new Queue<DialogueLine>();

    private DialogueBubble currentBubble;
    private GameObject currentBubbleGO;

    private bool isPlaying = false;

    // 用于挂载Canvas的UI根物体（用于气泡实例化）
    public Canvas uiCanvas;

    void Update()
    {
        if (isPlaying && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextLine();
        }
    }

    // 开始播放一组对话
    public void StartDialogue(List<DialogueLine> lines)
    {
        if (isPlaying)
            return;

        dialogueQueue.Clear();

        foreach (var line in lines)
        {
            dialogueQueue.Enqueue(line);
        }

        isPlaying = true;
        DisplayNextLine();
    }

    // 显示下一句
    private void DisplayNextLine()
    {
        if (currentBubbleGO != null)
        {
            Destroy(currentBubbleGO);
            currentBubbleGO = null;
            currentBubble = null;
        }

        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine line = dialogueQueue.Dequeue();

        currentBubbleGO = Instantiate(dialogueBubblePrefab, uiCanvas.transform);
        currentBubble = currentBubbleGO.GetComponent<DialogueBubble>();

        currentBubble.Show(line.speaker, line.text, line.speakerTransform);
    }

    private void EndDialogue()
    {
        isPlaying = false;
        if (currentBubbleGO != null)
        {
            Destroy(currentBubbleGO);
            currentBubbleGO = null;
            currentBubble = null;
        }
    }
}

[System.Serializable]
public class DialogueLine
{
    public string speaker;
    [TextArea(2, 4)]
    public string text;
    public Transform speakerTransform;

    public DialogueLine(string speaker, string text, Transform speakerTransform)
    {
        this.speaker = speaker;
        this.text = text;
        this.speakerTransform = speakerTransform;
    }
}
