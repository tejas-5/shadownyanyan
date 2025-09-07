using UnityEngine;
using TMPro;

public class DialogueBubble2D : MonoBehaviour
{
    public TextMeshPro textMesh;
    public Vector3 offset = new Vector3(0, 2f, 0);
    private Transform target;

    public void Initialize(Transform targetTransform, string text)
    {
        target = targetTransform;
        if (textMesh != null)
            textMesh.text = text;
        UpdatePosition();
    }

    void Update()
    {
        if (target != null)
            UpdatePosition();
    }

    void UpdatePosition()
    {
        transform.position = target.position + offset;
    }
}