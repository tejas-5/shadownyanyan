using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorController1 : MonoBehaviour
{
    public string nextSceneName;
    private bool playerInside = false;
    private bool shadowInside = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInside = true;
        if (collision.CompareTag("Shadow"))
            shadowInside = true;

        if (playerInside && shadowInside)
        {
            StartCoroutine(OpenDoorAndChangeScene());
        }
    }

    IEnumerator OpenDoorAndChangeScene()
    {
        animator.SetTrigger("Open");        // เล่นอนิเมชันประตูเปิด
        yield return new WaitForSeconds(1f); // รอให้ Animation เล่น
        if (!string.IsNullOrEmpty(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInside = false;
        if (collision.CompareTag("Shadow"))
            shadowInside = false;
    }
}