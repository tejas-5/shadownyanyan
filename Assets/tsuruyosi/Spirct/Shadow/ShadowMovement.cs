using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] ShadowSwitch shadowSwitch;
    [SerializeField] float speed;

    private Vector3 player;

    public bool b_move; //PlayerÇ∆âeÇÃëÄçÏÅ@OnOff

    private void Start()
    {
        
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player").transform.position;

        if (shadowSwitch.b_move == true)
        {
            Move();
        }
        else if(shadowSwitch.b_move == false)
        {
            GameObject.FindWithTag("shadow").transform.position = new Vector3(player.x, player.y, player.z);
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