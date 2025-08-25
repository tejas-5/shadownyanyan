using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("TriggerEnter2D ถูกเรียก โดย: " + other.name);

        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        {
            Debug.Log("ชนกับ Player หรือ Shadow: " + other.name);

            RestartOnHit restart = other.GetComponent<RestartOnHit>();
            if (restart != null)
            {
                Debug.Log("พบ RestartOnHit บน " + other.name);
                restart.RestartFromBeginning();
            }
            else
            {
                Debug.LogWarning("ไม่มี RestartOnHit บน " + other.name);
            }
        }

        Destroy(gameObject);
    }
}
