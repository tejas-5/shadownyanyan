using UnityEngine;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    public List<DialogueLine> lines; // บทสนทนา

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;

            DialogueController controller = FindFirstObjectByType<DialogueController>();
            if (controller != null)
            {
                GameObject player = other.gameObject;

                // หา Shadow ใน scene (ให้ตั้ง Tag = "Shadow")
                GameObject shadow = GameObject.FindWithTag("Shadow");

                controller.StartDialogue(lines, player, shadow);
            }
            else
            {
                Debug.LogError("DialogueController not found in scene!");
            }
        }
    }
}