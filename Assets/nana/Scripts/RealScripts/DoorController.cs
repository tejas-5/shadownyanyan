using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool doorOpened = false;

    public GameObject doorVisual; // สำหรับปิด/เปิดภาพประตู หรือใช้ Animation ก็ได้

    void Update()
    {
        if (!doorOpened && KeyManager.instance != null
            && KeyManager.instance.playerHasKey && KeyManager.instance.shadowHasKey)
        {
            OpenDoor();
        }
    }


    void OpenDoor()
    {
        doorOpened = true;

        if (doorVisual != null)
        {
            doorVisual.SetActive(false); // ปิดภาพประตู
        }

        Debug.Log("ประตูเปิดแล้ว!");
        // TODO: เพิ่มเสียง หรือโหลดฉากใหม่ตรงนี้
    }
}
