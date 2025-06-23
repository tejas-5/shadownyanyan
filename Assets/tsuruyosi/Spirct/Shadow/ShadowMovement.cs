using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] ShadowSwitch shadowSwitch;
    [SerializeField] float speed;

    private Vector3 player;

    public bool b_move; //PlayerÇ∆âe Ç«Ç¡ÇøÇ™à⁄ìÆÇ∑ÇÈÇÃÇ©Å@OnOff

    private void Start()
    {
        
    }

    void Update()
    {
        if (shadowSwitch.isMove == true)
        {
            Move();
        }
        else if(shadowSwitch.isMove == false)
        {
            transform.localScale = new Vector2(playerMovement.directionScale, 1);
        }
    }

    private void Move()
    {        
        Vector3 inputVector = new Vector3(0, 0, 0);
        if(playerMovement.isDirection == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                inputVector.x = 1;
                transform.localScale = new Vector2(playerMovement.directionScale, 1); //å¸Ç´
            }

            if (Input.GetKey(KeyCode.A))
            {
                inputVector.x = -1;
                transform.localScale = new Vector2(-playerMovement.directionScale, 1); //å¸Ç´
            }
        }else if(playerMovement.isDirection == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                inputVector.x = 1;
                transform.localScale = new Vector2(-playerMovement.directionScale, 1); //å¸Ç´
            }

            if (Input.GetKey(KeyCode.A))
            {
                inputVector.x = -1;
                transform.localScale = new Vector2(playerMovement.directionScale, 1); //å¸Ç´
            }
        }
        

        inputVector = inputVector.normalized;
        transform.position += inputVector * speed * Time.deltaTime;

    }


}