using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puzzle15Manager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform gridParent; // PuzzlePanel
    public GameObject bridge;
    public GameObject puzzleCanvas;

    private List<Tile> tiles = new List<Tile>();
    private Vector2Int emptyPos;

    private const int size = 4;

    void Start()
    {
        GenerateTiles();
        ShuffleTiles();
    }

    void GenerateTiles()
    {
        List<int> numbers = new List<int>();
        for (int i = 1; i <= 15; i++)
        {
            numbers.Add(i);
        }

        // ✅ สุ่มลำดับเลข
        for (int i = 0; i < numbers.Count; i++)
        {
            int rnd = Random.Range(i, numbers.Count);
            int temp = numbers[i];
            numbers[i] = numbers[rnd];
            numbers[rnd] = temp;
        }

        int count = 0;
        for (int i = 0; i < 16; i++)
        {
            GameObject tileObj = Instantiate(tilePrefab, gridParent);
            Tile tile = tileObj.AddComponent<Tile>();

            int number = (i == 15) ? 0 : numbers[count++];
            tile.Init(this, number, new Vector2Int(i % 4, i / 4));
            tiles.Add(tile);
        }

        tiles[15].SetEmpty(); // ช่องสุดท้ายเป็นช่องว่าง
    }

    void ShuffleTiles()
    {
        // สลับตำแหน่งแบบง่าย (ไม่รับประกัน solvable)
        for (int i = 0; i < 100; i++)
        {
            List<Tile> movable = tiles.FindAll(t => t.IsAdjacent(emptyPos));
            Tile randomTile = movable[Random.Range(0, movable.Count)];
            randomTile.OnClick(); // สลับกับช่องว่าง
        }
    }

    public void SwapTiles(Tile clickedTile)
    {
        Tile emptyTile = tiles.Find(t => t.isEmpty);

        // สลับ text
        string tempText = clickedTile.text.text;
        clickedTile.text.text = "";
        emptyTile.text.text = tempText;

        // ปรับค่า logic
        emptyTile.isEmpty = false;
        clickedTile.isEmpty = true;

        // สลับตำแหน่งใน list
        Vector2Int temp = clickedTile.pos;
        clickedTile.pos = emptyTile.pos;
        emptyTile.pos = temp;

        CheckWin();
    }

    public Tile GetEmptyTile()
    {
        return tiles.Find(t => t.isEmpty);
    }

    void CheckWin()
    {
        for (int i = 0; i < tiles.Count - 1; i++)
        {
            if (tiles[i].text.text != (i + 1).ToString())
                return;
        }

        // ช่องสุดท้ายควรเป็นว่าง
        if (tiles[tiles.Count - 1].text.text == "")
        {
            Debug.Log("You Win!");
            bridge.SetActive(true);
            puzzleCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}