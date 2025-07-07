using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
    public Vector2Int pos;
    public TMP_Text text;
    public bool isEmpty = false;
    private Puzzle15Manager manager;

    public void Init(Puzzle15Manager manager, int number, Vector2Int position)
    {
        this.manager = manager;
        this.pos = position;

        text = GetComponentInChildren<TMP_Text>();

        if (number < 16)
        {
            text.text = number.ToString();
        }
        else
        {
            SetEmpty();
        }

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        Tile emptyTile = manager.GetEmptyTile();

        if (IsAdjacent(emptyTile.pos))
        {
            manager.SwapTiles(this);
        }
    }

    public bool IsAdjacent(Vector2Int other)
    {
        return (Mathf.Abs(pos.x - other.x) + Mathf.Abs(pos.y - other.y)) == 1;
    }

    public void SetEmpty()
    {
        isEmpty = true;
        if (text != null)
            text.text = "";
    }
}