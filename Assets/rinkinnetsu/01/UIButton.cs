using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton: MonoBehaviour
{
    public void StartgameButton()
    {
        Debug.Log("GameStart");
        SceneManager.LoadScene("Test");
    }

    public void ExicGameButton()
    {
        Debug.Log("GameExic");
        Application.Quit();
    }
}
