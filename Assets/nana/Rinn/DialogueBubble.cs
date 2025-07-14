using TMPro;
using UnityEngine;

public class DialogueBubble : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Transform target;        // 跟随对象
    private Vector3 offset = new Vector3(0, 2.0f, 0);  // 气泡在角色头顶的偏移
    private Camera mainCamera;

    private bool isActive = false;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (target != null && isActive)
        {
            Vector3 worldPos = target.position + offset;
            Vector3 screenPos = mainCamera.WorldToScreenPoint(worldPos);
            transform.position = screenPos;
        }
    }

    // 初始化显示文本并指定跟随对象
    public void Show(string speaker, string text, Transform followTarget)
    {
        nameText.text = speaker;
        dialogueText.text = text;
        target = followTarget;
        isActive = true;
        gameObject.SetActive(true);
    }

    // 隐藏对话气泡
    public void Hide()
    {
        isActive = false;
        gameObject.SetActive(false);
    }
}