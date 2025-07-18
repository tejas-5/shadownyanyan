using UnityEngine;

public class ShadowRespawn : MonoBehaviour
{
    [SerializeField] Respawn respawn;

    [SerializeField] float positionY = -5;
    private Vector3 shadow;

    void Start()
    {
        
    }

    void Update()
    {
        DropDown();
    }

    //敵に当たった時
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            respawn.isRespawn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            respawn.isRespawn = false;
        }
    }

    //落とし穴に落ちた時
    void DropDown()
    {
        shadow = GameObject.FindWithTag("shadow").transform.position;
        if (shadow.y <= positionY)
        {
            respawn.isRespawn = true;
        }
        else respawn.isRespawn = false;
    }
}
