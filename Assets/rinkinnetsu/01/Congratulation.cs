using UnityEngine;
using UnityEngine.SceneManagement;

public class Congratulation : MonoBehaviour
{
    public void NextlevelGameButton()
    {
        Debug.Log("Next Level");
        SceneManager.LoadScene("Level2");
    }
    public void ReplayGameButtonn()
    {
        Debug.Log("Replay");
        SceneManager.LoadScene("Level1");
    }
    public void ExitButton()
    {
            Application.Quit();
            Debug.Log("Exit");
    }
}
