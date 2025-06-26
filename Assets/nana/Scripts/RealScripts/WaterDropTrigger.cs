using UnityEngine;

public class WaterDropTrigger : MonoBehaviour
{
    public Transform respawnPoint;

    void Start()
    {
        // ถ้ายังไม่ได้กำหนด respawnPoint → ใช้ตำแหน่งตอนเริ่มต้น
        if (respawnPoint == null)
        {
            GameObject defaultPoint = new GameObject($"{gameObject.name}_RespawnPoint");
            defaultPoint.transform.position = transform.position;
            respawnPoint = defaultPoint.transform;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WaterDrop"))
        {
            Debug.Log(gameObject.name + " hit water, respawning...");
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint.position;
    }
}