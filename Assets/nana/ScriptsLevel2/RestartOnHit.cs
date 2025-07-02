using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnHit : MonoBehaviour
{
    public void RestartFromBeginning()
    {
        Debug.Log("Restarting the scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}