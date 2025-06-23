using UnityEngine;

public class ShadowTrans : MonoBehaviour
{
    private Vector3 player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform.position; //Player‚ÌˆÊ’uŽæ“¾
        GameObject.FindWithTag("shadow").transform.position = new Vector3(player.x, player.y, player.z);

    }

    void Update()
    {
        
    }
}
