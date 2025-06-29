using UnityEngine;

public class ShadowAreaLightSwitch : MonoBehaviour
{
    public GameObject darkZoneMask; // ลาก DarkMask เข้า Inspector
    private bool isShadowInRange = false;

    void Update()
    {
        if (isShadowInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (darkZoneMask != null)
            {
                darkZoneMask.SetActive(false); // ปิดความมืด!
                Debug.Log("💡 Shadow เปิดไฟ!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow")) // ต้อง Tag = "Shadow"
        {
            isShadowInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            isShadowInRange = false;
        }
    }
}