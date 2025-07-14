using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Vector2Int pos;
    public bool isEmpty = false;

    private Puzzle15Manager manager;

    public void Init(Puzzle15Manager manager, int number, Vector2Int position)
    {
        this.manager = manager;
        this.pos = position;

        text = GetComponentInChildren<TextMeshProUGUI>();

        if (number == 0)
        {
            text.text = "";
            isEmpty = true;
            GetComponent<Button>().interactable = false; // empty tile can't be clicked
        }
        else
        {
            text.text = number.ToString();
            isEmpty = false;
            GetComponent<Button>().interactable = true;
        }

        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        Debug.Log($"Clicked tile pos: {pos}, Empty tile pos: {manager.GetEmptyTile().pos}");

        if (IsAdjacent(manager.GetEmptyTile().pos))
        {
            Debug.Log("Tiles are adjacent, swapping...");
            manager.SwapTiles(this);
        }
        else
        {
            Debug.Log("Tiles not adjacent, can't move.");
        }
    }

    public bool IsAdjacent(Vector2Int otherPos)
    {
        return Mathf.Abs(pos.x - otherPos.x) + Mathf.Abs(pos.y - otherPos.y) == 1;
    }

    public void SetEmpty()
    {
        isEmpty = true;
        text.text = "";
        GetComponent<Button>().interactable = false;
    }

    public void SetNumber(int number)
    {
        isEmpty = (number == 0);
        text.text = isEmpty ? "" : number.ToString();
        GetComponent<Button>().interactable = !isEmpty;
    }
}
