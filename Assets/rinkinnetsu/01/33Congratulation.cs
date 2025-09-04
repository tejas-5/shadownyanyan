using UnityEngine;
using UnityEngine.SceneManagement;

public class Congratulation33 : MonoBehaviour
{

    public void returnButton()
    {
        Debug.Log("start");
        SceneManager.LoadScene("Start");
    }
    public void ReplayGameButton()
    {
        Debug.Log("Replay");
        SceneManager.LoadScene("map");
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("");
    }
}
