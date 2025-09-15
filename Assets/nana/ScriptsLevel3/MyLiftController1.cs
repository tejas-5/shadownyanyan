using UnityEngine;
using UnityEngine.SceneManagement;

public class MyLiftController1 : MonoBehaviour
{
    [Header("ตั้งค่า Elevator")]
    public float speed = 2f;
    public float stopY = 5f;
    public string nextSceneName;

    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            if (transform.position.y >= stopY)
            {
                isMoving = false;
                Debug.Log("🏁 Elevator reached stopY");
                LoadNextScene();
            }
        }
    }

    // ฟังก์ชันให้สวิตช์เรียก
    public void ActivateLift()
    {
        if (!isMoving)
        {
            isMoving = true;
            Debug.Log("▶ Elevator activated!");
        }
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log($"🌐 Loading scene: {nextSceneName}");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}