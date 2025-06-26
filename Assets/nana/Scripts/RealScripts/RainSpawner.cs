using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    public GameObject dropPrefab;
    public int dropCount = 10;
    public float spacing = 0.5f;

    void Start()
    {
        for (int i = 0; i < dropCount; i++)
        {
            Vector3 spawnPos = transform.position + new Vector3(0, i * spacing, 0);
            Instantiate(dropPrefab, spawnPos, Quaternion.identity);
        }
    }
}
