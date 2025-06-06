using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] ShadowSwitch shadowSwitch;
    [SerializeField] float speed;
    int directionScale = 1; //Playerの向き

    public bool b_move; //Playerと影の操作　OnOff

    private void Start()
    {
        
    }

    void Update()
    {
        if (shadowSwitch.b_move == true)
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
            transform.localScale = new Vector2(directionScale, 1); //向き
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
            transform.localScale = new Vector2(-directionScale, 1); //向き
        }

        inputVector = inputVector.normalized;
        transform.position += inputVector * speed * Time.deltaTime;

    }
}