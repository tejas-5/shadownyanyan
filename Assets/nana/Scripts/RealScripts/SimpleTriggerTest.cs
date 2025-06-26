using UnityEngine;

public class SimpleTriggerTest : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{gameObject.name} triggered by {other.name}");
    }
}
