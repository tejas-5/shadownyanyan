using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    public GameObject realPlayer;
    public GameObject shadowPlayer;
    public CameraFollow cameraFollow;

    private bool isControllingReal = true;
    private bool isFollowing = true;
    private bool hasSeparated = false;

    void Start()
    {
        if (cameraFollow == null)
            cameraFollow = Camera.main.GetComponent<CameraFollow>();

        // Ensure both players are active so they can be moved
        realPlayer.SetActive(true);
        shadowPlayer.SetActive(true);

        // Set initial control: real player is active, shadow is inactive
        SetPlayerControl(realPlayer, true);
        SetPlayerControl(shadowPlayer, false);

        // Position shadow player on top of real player
        shadowPlayer.transform.position = realPlayer.transform.position;

        isControllingReal = true;
        isFollowing = true;
        hasSeparated = false;

        if (cameraFollow != null)
            cameraFollow.SetTarget(realPlayer.transform);
    }

    void Update()
    {
        // Keep shadow following real player before separation
        if (isFollowing && shadowPlayer.activeSelf)
        {
            shadowPlayer.transform.position = realPlayer.transform.position;
        }

        // Space key: switch control or separate
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressed SPACE");

            if (!hasSeparated)
            {
                hasSeparated = true;
                isFollowing = false;
                isControllingReal = false;

                SetPlayerControl(realPlayer, false);
                SetPlayerControl(shadowPlayer, true);

                cameraFollow?.SetTarget(shadowPlayer.transform);
            }
            else
            {
                isControllingReal = !isControllingReal;

                SetPlayerControl(realPlayer, isControllingReal);
                SetPlayerControl(shadowPlayer, !isControllingReal);

                cameraFollow?.SetTarget(isControllingReal ? realPlayer.transform : shadowPlayer.transform);
            }
        }

        // R key: reset back to original state
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Pressed R");

            isFollowing = true;
            hasSeparated = false;
            isControllingReal = true;

            shadowPlayer.transform.position = realPlayer.transform.position;

            SetPlayerControl(realPlayer, true);
            SetPlayerControl(shadowPlayer, false);

            cameraFollow?.SetTarget(realPlayer.transform);
        }
    }

    void SetPlayerControl(GameObject obj, bool active)
    {
        var pc = obj.GetComponent<PlayerController>();
        var rb = obj.GetComponent<Rigidbody2D>();

        if (pc != null) pc.enabled = active;
        if (rb != null) rb.simulated = active;
    }
}