using UnityEngine;

public class UnlockTarget : MonoBehaviour
{
    public GameObject hiddenPuzzlePlate; // แผ่นที่ 4 ที่จะปรากฏ

    public void Unlock()
    {
        Debug.Log("เปิดกล่อง/ประตูเรียบร้อย!");

        // วิธีที่ 1: ทำให้กล่องหายไป
        gameObject.SetActive(false);

        // วิธีที่ 2: หรือใส่อนิเมชั่นเปิด (แล้วใช้ Animation Event ก็ได้)

        // แสดงแผ่นพัซเซิล
        if (hiddenPuzzlePlate != null)
        {
            hiddenPuzzlePlate.SetActive(true);
        }
    }
}
