using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowBoxController : MonoBehaviour
{
    public Transform realBox; // กล่องจริง
    public Light2D lightSource;
    public float lightRadius = 5f;
    public float offsetX = 1.5f;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (!realBox || !lightSource) { Debug.LogError("❌ Assign realBox & lightSource!"); enabled = false; return; }
        sr.enabled = false;
    }

    void Update()
    {
        float dist = Vector2.Distance(realBox.position, lightSource.transform.position);
        if (dist > lightRadius)
        {
            sr.enabled = false;
            return;
        }

        sr.enabled = true;

        // 👉 เงาเลื่อนไปด้านซ้ายหรือขวาเท่านั้น
        Vector2 fromLight = (realBox.position - lightSource.transform.position).normalized;
        float xDir = Mathf.Sign(fromLight.x);
        Vector3 shadowPos = realBox.position + new Vector3(xDir * offsetX, 0, 0);

        transform.position = shadowPos;
    }
}