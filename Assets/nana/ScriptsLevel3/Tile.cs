using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Vector2Int pos;   // logical position
    public bool isEmpty = false;
    public int number;       // สำหรับเช็ค win

    private Puzzle15Manager manager;
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Init(Puzzle15Manager manager, int number, Vector2Int position)
    {
        this.manager = manager;
        this.pos = position;

        SetNumber(number);

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (manager == null) return;

        Tile emptyTile = manager.GetEmptyTile();
        bool canMove = IsAdjacent(emptyTile.pos);

        Debug.Log($"Clicked tile {number} at {pos}, empty tile at {emptyTile.pos}, canMove: {canMove}");

        if (canMove)
        {
            manager.SwapTiles(this);
        }
    }

    public bool IsAdjacent(Vector2Int otherPos)
    {
        return Mathf.Abs(pos.x - otherPos.x) + Mathf.Abs(pos.y - otherPos.y) == 1;
    }

    public void SetEmpty()
    {
        number = 0;
        isEmpty = true;
        text.text = "";
        button.interactable = false; // empty tile can't be clicked
    }

    public void SetNumber(int num)
    {
        number = num;
        isEmpty = (num == 0);
        text.text = isEmpty ? "" : num.ToString();
        button.interactable = true; // all number tiles clickable
    }
}