using UnityEngine;

public class WaterDropSpawner : MonoBehaviour
{
    public GameObject waterDropPrefab;
    public float dropInterval = 1f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnDrop), 0f, dropInterval);
    }

    void SpawnDrop()
    {
        Instantiate(waterDropPrefab, transform.position, Quaternion.identity);
    }
}