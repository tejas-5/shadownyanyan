using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 tmp;
    void Start()
    {
        //tmp = GameObject.FindWithTag("Respawn").transform.position;　//リスポーン地点の位置取得
    }

    void Update()
    {
        //エネミーにぶつかった時or落とし穴に落ちた時↓
        //GameObject.FindWithTag("Player").transform.position = new Vector3(tmp.x, tmp.y + 2, tmp.z);　//スポーン地点に移動
    }
}
