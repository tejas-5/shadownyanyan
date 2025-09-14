using UnityEngine;

public class CameraZone : MonoBehaviour
{
    [Header("Zone Offset (applies only when shadow is target)")]
    public Vector3 zoneOffset = new Vector3(-1f, -2f, 0f);

    private CameraFollow cameraFollow;

    void Start()
    {
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollow == null)
        {
            Debug.LogWarning("⚠️ CameraZone: No CameraFollow found on Main Camera!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            //cameraFollow?.SetZoneOffset(zoneOffset, true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            //cameraFollow?.SetZoneOffset(Vector3.zero, false);
        }
    }
}
