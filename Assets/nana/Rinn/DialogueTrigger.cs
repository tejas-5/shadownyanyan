using UnityEngine;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    public List<DialogueLine> lines;
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            DialogueControllerUI controller = FindObjectOfType<DialogueControllerUI>();
            if (controller != null && lines.Count > 0)
            {
                controller.StartDialogue(lines); // ส่งบทพูดไปให้ Controller
            }
        }
    }
}