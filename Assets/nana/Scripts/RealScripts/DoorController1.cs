using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController1 : MonoBehaviour
{
    public string nextSceneName;  // กำหนดชื่อ Scene ที่จะโหลด ผ่าน Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogWarning("Next scene name is not set!");
            }
        }
    }
}