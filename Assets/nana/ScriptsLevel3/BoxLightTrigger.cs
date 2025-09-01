using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BoxLightTrigger : MonoBehaviour
{
    public Light2D boxLight;
    public string boxTag = "PushableBox";

    public ShadowPlatformController targetPlatform; // 👈 เพิ่มตรงนี้

    private bool boxInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(boxTag))
        {
            boxInside = true;
            UpdateLight();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(boxTag))
        {
            boxInside = false;
            UpdateLight();
        }
    }

    void UpdateLight()
    {
        // เปิดไฟตามกล่อง
        boxLight.enabled = boxInside;

        // เปิด/ปิด Platform ตามไฟ
        if (targetPlatform != null)
        {
            if (boxInside)
                targetPlatform.ActivatePlatform();
            else
                targetPlatform.DeactivatePlatform();
        }
    }
}