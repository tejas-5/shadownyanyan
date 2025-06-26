using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowBoxController : MonoBehaviour
{
    public Light2D shadowLight;
    private Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        if (col == null)
        {
            Debug.LogError("ShadowBoxController: ไม่มี Collider2D!");
        }
    }

    void Update()
    {
        if (shadowLight == null)
        {
            Debug.LogWarning("ShadowBoxController: shadowLight ยังไม่ได้ assign");
            return;
        }

        Debug.Log("Shadow Light Intensity: " + shadowLight.intensity);
        bool lightOn = shadowLight.intensity > 0.01f;

        col.enabled = lightOn;
    }
}
   