using UnityEngine;

public class ShadowSwitch : MonoBehaviour
{
    public bool b_move;
    void Start()
    {
        b_move = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(b_move == false)
            {
                b_move = true;
            }
            else if (b_move == true)
            {
                b_move = false;
            }
        }
    }
}
