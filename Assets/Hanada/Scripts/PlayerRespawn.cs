using UnityEngine;

public class PlayerRespawn2D : MonoBehaviour
{
    public void Respawn()
    {
        transform.position = Checkpoint2D.lastCheckpointPosition;
        Debug.Log("リスポーンしました: " + Checkpoint2D.lastCheckpointPosition);
    }
}
