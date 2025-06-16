using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ShadowSwitch shadowSwitch;
    [SerializeField] float speed;
    public bool isDirection; //Player‚ÌŒü‚«
    public int directionScale = 1; //Player‚ÌŒü‚«

    private void Start()
    {

    }

    void Update()
    {
        if(shadowSwitch.isMove == false)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 inputVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
            transform.localScale = new Vector2(directionScale, 1); //Œü‚«
            isDirection = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
            transform.localScale = new Vector2(-directionScale, 1); //Œü‚«
            isDirection = false;
        }

        inputVector = inputVector.normalized;
        transform.position += inputVector * speed * Time.deltaTime;

    }
}