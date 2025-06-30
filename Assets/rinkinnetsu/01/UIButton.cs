using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public void StartgameButton()
    {
        Debug.Log("play");
        SceneManager.LoadScene("Levels");
    }
    public void wanfagameButton()
    {
        Debug.Log("Game Rules");
        SceneManager.LoadScene("wanfa");
    }
    public void OptionButton()
    {
        Debug.Log("Option");
        SceneManager.LoadScene("Option");
    }

    public void ExitGameButton()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}