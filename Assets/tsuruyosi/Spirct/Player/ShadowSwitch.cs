using UnityEngine;

public class ShadowSwitch : MonoBehaviour
{
    public GameObject Shadow;
    public bool isMove;
    public bool b_move;

    float x;
    float y;
    float z;
    private Vector3 player;
    private Transform shadow;
    void Start()
    {
        //shadow = GetComponent.FindWithTag("shadow").<Transform>();
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
                shadowtrans();
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
            b_move = false;
            Shadow.SetActive(false);
        }
    }

    void shadowtrans()
    {
        player = GameObject.FindWithTag("Player").transform.position;
        x = player.x;
        y = player.y;
        x = player.z;
        //shadow.
    }
}
