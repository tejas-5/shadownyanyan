using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ElevatorPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float stopY = 5f;
    public string nextSceneName;

    private bool isMoving = false;

    public void ActivateLift()
    {
        if (!isMoving && gameObject.activeInHierarchy)
        {
            isMoving = true;
            StartCoroutine(MoveLift());
        }
    }

    private IEnumerator MoveLift()
    {
        while (transform.position.y < stopY)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;

        if (!string.IsNullOrEmpty(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // ปลอดภัย: เรียก Coroutine เฉพาะตอน Active
        if (collision.gameObject.CompareTag("Player") && gameObject.activeInHierarchy)
        {
            StartCoroutine(MoveLift());
        }
    }
}