
using UnityEngine;

public class SwitchScript3 : MonoBehaviour
{
    public ElevatorController elevator; // 👉 เพิ่มตรงนี้ใน Inspector
    private bool isShadowOnSwitch = false;
    private bool hasActivated = false; // ป้องกันเรียกซ้ำ

    void Update()
    {
        if (isShadowOnSwitch && Input.GetKeyDown(KeyCode.E) && !hasActivated)
        {
            Debug.Log("กด E เพื่อเปิดสวิตช์แล้ว");
            elevator.Toggle(); // ✅ เรียกให้ลิฟต์ทำงาน
            hasActivated = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            isShadowOnSwitch = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            isShadowOnSwitch = false;
        }
    }
}