using UnityEngine;
using UnityEngine.SceneManagement;

public class wanfa : MonoBehaviour
{
    public void returnButton()
    {
        Debug.Log("Button");
        SceneManager.LoadScene("Start");
    }
}
