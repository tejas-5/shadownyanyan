using UnityEngine;
using UnityEngine.SceneManagement;

public class MyLiftController1 : MonoBehaviour
{

    [Header("ตั้งค่า Elevator")]
    public float speed = 2f;
    public float stopY = 5f;
    public string nextSceneName;

    [Header("Trigger และ Key")]
    public KeyCode activateKey = KeyCode.E;

    private bool isMoving = false;
    private bool canActivate = false;
    private Transform realPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ตรวจเฉพาะ RealPlayer
        if (collision.CompareTag("Player"))
        {
            canActivate = true;
            realPlayer = collision.transform;
            Debug.Log($"🚪 RealPlayer entered lift trigger: {realPlayer.name}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivate = false;
            realPlayer = null;
            Debug.Log("🚪 RealPlayer exited lift trigger");
        }
    }

    void Update()
    {
        if (canActivate && Input.GetKeyDown(activateKey) && !isMoving)
        {
            isMoving = true;
            Debug.Log("▶ Elevator activated by RealPlayer!");
        }

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

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log($"🌐 Loading scene: {nextSceneName}");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}