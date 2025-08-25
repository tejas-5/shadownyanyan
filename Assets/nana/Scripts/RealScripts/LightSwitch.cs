using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightToTurnOn;

    private bool isPlayerInRange = false;
    private bool isLightOn = false;

    void Start()
    {
        if (lightToTurnOn != null)
        {
            // Start with the light turned off
            lightToTurnOn.SetActive(false);
            isLightOn = false;
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            isLightOn = !isLightOn;

            if (lightToTurnOn != null)
            {
                lightToTurnOn.SetActive(isLightOn);
                Debug.Log(isLightOn ? "ไฟเปิดแล้ว!" : "ไฟปิดแล้ว!");
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
