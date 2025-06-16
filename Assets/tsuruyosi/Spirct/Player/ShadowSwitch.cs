using UnityEngine;

public class ShadowSwitch : MonoBehaviour
{
    public GameObject Shadow;
    public bool isMove;
    public bool b_move;

    private Vector3 player;
    private Vector3 shadow;
    void Start()
    {
        shadow = GameObject.FindWithTag("shadow").transform.position;
        isMove = false;
        b_move = false;
        Shadow.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isMove == false)
            {
                isMove = true;
            }else if(isMove == true)
            {
                isMove = false;
            }
        }

        if (isMove == true)
        {
            b_move = true;
            Shadow.SetActive(true);
        }
        else if (isMove == false)
        {
            shadowtrans();
            b_move = false;
            Shadow.SetActive(false);
        }
    }

    void shadowtrans()
    {
        player = GameObject.FindWithTag("Player").transform.position;
        shadow.x = player.x;
        shadow.y = player.y;
        shadow.x = player.z;
    }
}
