using UnityEngine;

public class NumberPlatePickup : MonoBehaviour
{
    public GameObject platePrefab;
    public Vector3 plateOffset = new Vector3(0, 1.5f, 0);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        {
            Transform headHolder = other.transform.Find("PlateHolder");

            if (headHolder != null)
            {
                int count = headHolder.childCount;

                Vector3 spawnPos = other.transform.position + plateOffset + new Vector3(count * 0.6f, 0, 0);
                GameObject newPlate = Instantiate(platePrefab, spawnPos, Quaternion.identity);
                newPlate.transform.SetParent(headHolder);

                // ✅ อัปเดต collector ที่ถูกต้อง
                PuzzleCollector collector = other.GetComponent<PuzzleCollector>();
                if (collector != null)
                {
                    collector.numbersCollected++;
                    Debug.Log("เก็บพัซเซิลแล้ว: " + collector.numbersCollected);
                }

                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("ไม่มี PlateHolder ใน " + other.name);
            }
        }
    }
}