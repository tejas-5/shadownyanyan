using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public LiftController lift; // ลิฟต์ที่จะควบคุม
    public float interactDistance = 2f; // ระยะที่กดสวิตช์ได้

    public Transform realPlayer;   // ผู้เล่นตัวจริง
    public Transform shadowPlayer; // เงาผู้เล่น

    void Update()
    {
        if (realPlayer == null || shadowPlayer == null)
        {
            Debug.LogError("ตั้งค่า realPlayer และ shadowPlayer ใน Inspector ให้เรียบร้อย");
            return;
        }

        bool canInteract = false;

        // เช็คระยะกับผู้เล่นตัวจริง
        if (Vector3.Distance(realPlayer.position, transform.position) <= interactDistance)
        {
            canInteract = true;
        }
        // เช็คระยะกับเงาผู้เล่น
        else if (Vector3.Distance(shadowPlayer.position, transform.position) <= interactDistance)
        {
            canInteract = true;
        }

        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            lift.Toggle();
            Debug.Log("กดสวิตช์ เปิด/ปิดลิฟต์");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactDistance);
    }
}