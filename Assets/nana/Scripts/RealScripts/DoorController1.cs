using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController1 : MonoBehaviour
{
    public string nextSceneName = "Level2";  // ตั้งชื่อ Scene ต่อไปที่นี่

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}