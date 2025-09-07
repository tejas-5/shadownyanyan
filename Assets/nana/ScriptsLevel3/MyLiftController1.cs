using UnityEngine;
using UnityEngine.SceneManagement;

public class MyLiftController1 : MonoBehaviour
{
    public float speed = 2f;          // ความเร็วลิฟท์
    public float stopY = 5f;          // จุดสูงสุดที่ลิฟท์หยุดและเปลี่ยน Scene
    public string nextSceneName;      // ชื่อ Scene ถัดไป
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            // เช็คว่าถึงจุดเปลี่ยน Scene หรือยัง
            if (transform.position.y >= stopY)
            {
                isMoving = false;
                LoadNextScene();
            }
        }
    }

    public void ActivateLift()
    {
        isMoving = true;
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}