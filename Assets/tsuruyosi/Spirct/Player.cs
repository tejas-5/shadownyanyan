using UnityEngine;

public class Player : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //�E
            Vector2 pos = transform.position;
            pos.x += 0.05f;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //��
            Vector2 pos = transform.position;
            pos.x -= 0.05f;
            transform.position = pos;
        }
    }
}
