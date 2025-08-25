using UnityEngine;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    public List<DialogueLine> lines;   // Inspector ให้ใส่บทพูดพร้อมเลือก Speaker
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            FindObjectOfType<DialogueController>().StartDialogue(lines);
        }
    }
}