using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsButton : MonoBehaviour
{
    public void GameButton()
    {
        Debug.Log("1");
        SceneManager.LoadScene("Level1");
    }
    public void erGameButton()
    {
        Debug.Log("2");
        SceneManager.LoadScene("Level2");
    }
    public void sannGameBotton()
    {
        Debug.Log("3");
        SceneManager.LoadScene("map");
    }
    public void returnButton()
    {
        Debug.Log("return");
        SceneManager.LoadScene("Start");
     }
}
