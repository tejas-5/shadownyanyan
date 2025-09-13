using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;

    private int playerKeys = 0;
    private int shadowKeys = 0;

    // เพิ่ม getter สำหรับตรวจสอบสถานะกุญแจ
    public bool playerHasKey => playerKeys > 0;
    public bool shadowHasKey => shadowKeys > 0;

    public enum OwnerType { Player, Shadow }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PickupKey(OwnerType owner)
    {
        if (owner == OwnerType.Player)
        {
            playerKeys++;
            Debug.Log("Player เก็บกุญแจ: " + playerKeys);
        }
        else if (owner == OwnerType.Shadow)
        {
            shadowKeys++;
            Debug.Log("Shadow เก็บกุญแจ: " + shadowKeys);
        }
    }

    public bool HasAllKeys()
    {
        return playerHasKey && shadowHasKey;
    }
}
