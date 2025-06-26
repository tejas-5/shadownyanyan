using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightToTurnOn;

    private bool isPlayerInRange = false;
    private bool isLightOn = false;

    private Light2D light2D;

    void Start()
    {
        if (lightToTurnOn != null)
        {
            light2D = lightToTurnOn.GetComponent<Light2D>();

            if (light2D != null)
            {
                // ถ้า intensity = 0 ตั้ง enabled เป็น false ให้แน่ใจ
                light2D.enabled = light2D.intensity > 0;
            }
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (light2D != null)
            {
                isLightOn = !isLightOn;

                if (isLightOn)
                {
                    light2D.enabled = true;
                    light2D.intensity = 1f; // ปรับเป็นค่าที่ต้องการ
                }
                else
                {
                    light2D.intensity = 0f;
                    light2D.enabled = false;
                }

                Debug.Log(isLightOn ? "ไฟเปิดแล้ว!" : "ไฟปิดแล้ว!");
            }
            else if (lightToTurnOn != null)
            {
                // กรณีไม่มี Light2D ก็เปิด/ปิด GameObject แทน
                isLightOn = !isLightOn;
                lightToTurnOn.SetActive(isLightOn);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInRange = false;
    }
}
