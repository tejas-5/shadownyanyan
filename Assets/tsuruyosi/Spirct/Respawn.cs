using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 tmp;
    void Start()
    {
        //tmp = GameObject.FindWithTag("Respawn").transform.position;�@//���X�|�[���n�_�̈ʒu�擾
    }

    void Update()
    {
        //�G�l�~�[�ɂԂ�������or���Ƃ����ɗ���������
        //GameObject.FindWithTag("Player").transform.position = new Vector3(tmp.x, tmp.y + 2, tmp.z);�@//�X�|�[���n�_�Ɉړ�
    }
}
