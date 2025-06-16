using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] ShadowSwitch shadowSwitch;
    [SerializeField] float positionY = -5;
    private Vector3 tmp;
    private Vector3 player;

    public bool isRespawn;
    void Start()
    {
        tmp = GameObject.FindWithTag("Respawn").transform.position;�@//���X�|�[���n�_�̈ʒu�擾
    }

    void Update()
    {
        RespawnCondition();
        DropDown();
    }

    private void RespawnCondition()
    {
        if(isRespawn == true)
        {
            //�X�|�[���n�_�Ɉړ�
            GameObject.FindWithTag("Player").transform.position = new Vector3(tmp.x, tmp.y + 2, tmp.z);
            shadowSwitch.isMove = false;
        }
    }

    //�G�ɓ���������
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            isRespawn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            isRespawn = false;
        }
    }

    //���Ƃ����ɗ�������
    void DropDown()
    {
        player = GameObject.FindWithTag("Player").transform.position;
        if (player.y <= positionY)
        {
            isRespawn = true;
        } else isRespawn = false;

        if (isRespawn == true)
        {
            //�X�|�[���n�_�Ɉړ�
            GameObject.FindWithTag("Player").transform.position = new Vector3(tmp.x, tmp.y + 2, tmp.z);
        }
    }
}
