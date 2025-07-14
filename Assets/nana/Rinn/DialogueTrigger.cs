using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<DialogueLine> dialogueLines;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered)
            return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            DialogueManager manager = FindObjectOfType<DialogueManager>();
            if (manager != null)
            {
                manager.StartDialogue(dialogueLines);
            }
            else
            {
                Debug.LogError("场景中没有DialogueManager");
            }
        }
    }
}