using UnityEngine;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    public List<DialogueLine> lines;   // ใส่บทพูดพร้อมเลือก Speaker ใน Inspector
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;

            // หา DialogueController ใน Scene และเริ่ม Dialogue
            DialogueController controller = FindFirstObjectByType<DialogueController>();
            if (controller != null)
                controller.StartDialogue(lines);
            else
                Debug.LogError("DialogueController not found in scene!");
        }
    }
}