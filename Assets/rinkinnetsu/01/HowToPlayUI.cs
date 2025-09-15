using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToPlayUI : MonoBehaviour
{
    [Header("Pages")]
    public GameObject[] pages;   // เก็บ Page1-5
    private int currentPage = 0;

    [Header("UI Buttons")]
    public Button backButton;
    public Button leftArrow;
    public Button rightArrow;
    public Button targetButton;  // 目標
    public Button howtoButton;   // 遊び方
    public Button puzzleButton;  // パズル

    void Start()
    {
        ShowPage(0);

        // set listener
        backButton.onClick.AddListener(() => SceneManager.LoadScene("Start"));
        leftArrow.onClick.AddListener(PrevPage);
        rightArrow.onClick.AddListener(NextPage);

        targetButton.onClick.AddListener(() => ShowPage(0)); // หน้า1
        howtoButton.onClick.AddListener(() => ShowPage(1));  // หน้า2
        puzzleButton.onClick.AddListener(() => ShowPage(3)); // หน้า4
    }

    void ShowPage(int index)
    {
        if (index < 0 || index >= pages.Length) return;
        currentPage = index;

        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == currentPage);
        }
    }

    void PrevPage()
    {
        int newPage = currentPage - 1;
        if (newPage < 0) newPage = pages.Length - 1;
        ShowPage(newPage);
    }

    void NextPage()
    {
        int newPage = (currentPage + 1) % pages.Length;
        ShowPage(newPage);
    }
}