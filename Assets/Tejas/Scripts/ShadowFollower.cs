using UnityEngine;

public class ShadowFollower : MonoBehaviour
{
    [Tooltip("The RealPlayer Transform to follow")]
    public Transform realPlayer;

    [HideInInspector]
    public bool followReal = false;

    void LateUpdate()
    {
        if (followReal)
        {
            // Immediately snap shadow on top of the real player
            transform.position = realPlayer.position;
        }
    }
}
