using UnityEngine;
using UnityEngine.SceneManagement;

public class Congratulation22 : MonoBehaviour
{
    public void NextLevelGameButton()
    {
        Debug.Log("Next Level");
        SceneManager.LoadScene("map");
    }
    public void ReplayGameButton()
    {
        Debug.Log("Replay");
        SceneManager.LoadScene("Level2");
    }
    public void Replay3GameButton()
    {
        Debug.Log("Replay");
        SceneManager.LoadScene("map");
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}