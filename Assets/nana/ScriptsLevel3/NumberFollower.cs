using UnityEngine;

public class NumberFollower : MonoBehaviour
{
    public Transform playerHead; // Transform บนหัวผู้เล่น
    public Vector3 offset = new Vector3(0, 2f, 0); // ระยะห่างเหนือหัว

    void LateUpdate()
    {
        transform.position = playerHead.position + offset;
    }
}
