using UnityEngine;

public class ShadowSwitch3 : MonoBehaviour
{
    public MyLiftController1 lift;    // ลากลิฟต์มาใส่ใน Inspector
    public KeyCode activateKey = KeyCode.E;

    private bool canActivate = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shadow")) // ✅ ตรวจเฉพาะตัวเงา
        {
            canActivate = true;
            Debug.Log("🔘 Shadow entered switch trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Shadow"))
        {
            canActivate = false;
            Debug.Log("🔘 Shadow exited switch trigger");
        }
    }

    private void Update()
    {
        if (canActivate && Input.GetKeyDown(activateKey))
        {
            lift.ActivateLift(); // เรียกลิฟต์
        }
    }
}