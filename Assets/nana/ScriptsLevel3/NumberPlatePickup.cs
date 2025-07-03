using UnityEngine;

public class NumberPlatePickup : MonoBehaviour
{
    public GameObject platePrefab;  // Prefab ที่จะลอยบนหัว (แผ่นตัวเลข)
    public Vector3 plateOffset = new Vector3(0, 1.5f, 0); // ตำแหน่งลอย

    private void OnTriggerEnter2D(Collider2D other)
    {
        // รับได้ทั้ง Player และ Shadow
        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        {
            Transform headHolder = other.transform.Find("PlateHolder");

            if (headHolder != null)
            {
                // นับจำนวนแผ่นที่ติดอยู่
                int count = headHolder.childCount;

                // สร้างแผ่นใหม่
                Vector3 spawnPos = other.transform.position + plateOffset + new Vector3(count * 0.6f, 0, 0);
                GameObject newPlate = Instantiate(platePrefab, spawnPos, Quaternion.identity);
                newPlate.transform.SetParent(headHolder); // ติดไว้กับหัวผู้เล่นหรือเงา

                Destroy(gameObject); // ลบแผ่นจากฉาก
            }
            else
            {
                Debug.LogWarning("ไม่มี PlateHolder ใน " + other.name);
            }
        }
    }
}