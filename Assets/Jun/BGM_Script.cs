using UnityEngine;
using UnityEngine.Audio;

public class BGM_Script : MonoBehaviour
{
    public static BGM_Script instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}