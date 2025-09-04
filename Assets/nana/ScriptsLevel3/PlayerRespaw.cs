using UnityEngine;

public class PlayerRespaw : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.hasSavedPosition)
        {
            // ✅ ย้าย Player กลับไปตำแหน่งล่าสุด
            transform.position = GameManager.Instance.lastPlayerPosition;
        }
    }
}
