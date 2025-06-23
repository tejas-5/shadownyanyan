using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    public GameObject realPlayer;
    public GameObject shadowPlayer;

    private bool isControllingReal = true;
    private bool shadowCreated = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!shadowCreated)
            {
                shadowPlayer.SetActive(true);
                shadowCreated = true;

                isControllingReal = false;
                SetControl(realPlayer, false);
                SetControl(shadowPlayer, true);
            }
            else
            {
                isControllingReal = !isControllingReal;
                SetControl(realPlayer, isControllingReal);
                SetControl(shadowPlayer, !isControllingReal);
            }
        }
    }

    void SetControl(GameObject obj, bool active)
    {
        MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script is PlayerController || script is ShadowPlayerController)
            {
                script.enabled = active;
            }
        }

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.simulated = active;
    }
}