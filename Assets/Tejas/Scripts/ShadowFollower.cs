using UnityEngine;

public class ShadowFollower : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(-0.5f, -0.1f, 0);
    public float followSpeed = 10f;

    private bool following = true;

    void Update()
    {
        if (following && target != null)
        {
            Debug.Log("Following to " + target.name);  // 👈 ดูว่า target คืออะไร

            transform.position = target.position + offset;
        }
    }

    public void StopFollowing()
    {
        following = false;
    }

    // 👇 เพิ่มเมธอดนี้
    public void SetFollowing(bool value)
    {
        following = value;
    }
}