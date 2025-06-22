using UnityEngine;

public class ShadowFollower : MonoBehaviour
{
    [Tooltip("The RealPlayer Transform to follow")]
    public Transform realPlayer;

    [Tooltip("Offset from the real player's position")]
    public Vector3 positionOffset = new Vector3(0f, 0f, 0f);

    [HideInInspector]
    public bool followReal = false;

    void LateUpdate()
    {
        if (followReal)
        {
            transform.position = realPlayer.position + positionOffset;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Lift"))
        {
            transform.SetParent(col.transform); // ติดลิฟต์
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Lift"))
        {
            transform.SetParent(null); // หลุดจากลิฟต์
        }
    }

}
