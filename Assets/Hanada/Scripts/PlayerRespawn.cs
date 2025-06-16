using UnityEngine;

public class PlayerRespawn2D : MonoBehaviour
{
    public void Respawn()
    {
        transform.position = Checkpoint2D.lastCheckpointPosition;
        Debug.Log("ƒŠƒXƒ|[ƒ“‚µ‚Ü‚µ‚½: " + Checkpoint2D.lastCheckpointPosition);
    }
}
