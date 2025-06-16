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

    //“G‚É“–‚½‚Á‚½Žž
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

    //—Ž‚Æ‚µŒŠ‚É—Ž‚¿‚½Žž
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
