using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [Tooltip("อ้างถึงวัตถุไฟที่จะเปิด")]
    public GameObject lightToTurnOn;

    private bool isPlayerInRange = false;
    private bool isLightOn = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (lightToTurnOn != null && !isLightOn)
            {
                lightToTurnOn.SetActive(true);
                isLightOn = true;

                Debug.Log("ไฟเปิดแล้ว!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}

