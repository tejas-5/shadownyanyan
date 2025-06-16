using UnityEngine;

public class RespawnTrigger2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn2D respawn = other.GetComponent<PlayerRespawn2D>();
            if (respawn != null)
            {
                respawn.Respawn();
            }
        }
    }
}
