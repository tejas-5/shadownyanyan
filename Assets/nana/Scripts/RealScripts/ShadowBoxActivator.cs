using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowBoxActivator : MonoBehaviour
{
    public GameObject shadowBox; // กล่องเงา (ปิดไว้ใน Inspector)
    public Light2D triggerLight; // ไฟที่ใช้ตรวจสอบ
    public float triggerRadius = 5f; // ระยะที่กล่องจริงต้องอยู่ถึงเปิดเงา
    public Transform realBox; // กล่องจริง

    void Start()
    {
        if (shadowBox != null)
            shadowBox.SetActive(false); // ปิดเริ่มต้น
    }

    void Update()
    {
        if (shadowBox == null || realBox == null || triggerLight == null)
            return;

        // ตรวจสอบระยะจากไฟ
        float dist = Vector2.Distance(realBox.position, triggerLight.transform.position);

        // เปิดกล่องเงาเมื่ออยู่ในรัศมีไฟ
        shadowBox.SetActive(dist <= triggerRadius);
    }
}
