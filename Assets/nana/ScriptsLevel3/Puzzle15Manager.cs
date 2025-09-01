using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Puzzle15Manager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform gridParent;
    private List<Tile> tiles = new List<Tile>();
    private const int size = 4;

    void Start()
    {
        GenerateTiles();
        ShuffleTiles();
    }

    void GenerateTiles()
    {
        int count = 1;
        for (int i = 0; i < size * size; i++)
        {
            GameObject tileObj = Instantiate(tilePrefab, gridParent);
            Tile tile = tileObj.GetComponent<Tile>();
            int number = (i == size * size - 1) ? 0 : count++;
            Vector2Int pos = new Vector2Int(i % size, i / size);
            tile.Init(this, number, pos);
            tiles.Add(tile);
        }
    }

    public Tile GetEmptyTile()
    {
        return tiles.Find(t => t.isEmpty);
    }

    public void SwapTiles(Tile clickedTile)
    {
        Tile emptyTile = GetEmptyTile();
        if (!clickedTile.IsAdjacent(emptyTile.pos)) return;

        int clickedNumber = int.Parse(clickedTile.text.text);
        clickedTile.SetEmpty();
        emptyTile.SetNumber(clickedNumber);

        Vector2Int tempPos = clickedTile.pos;
        clickedTile.pos = emptyTile.pos;
        emptyTile.pos = tempPos;

        CheckWin();
    }

    void ShuffleTiles()
    {
        for (int i = 0; i < 100; i++)
        {
            Tile emptyTile = GetEmptyTile();
            List<Tile> adjacentTiles = new List<Tile>();
            foreach (var tile in tiles)
                if (tile.IsAdjacent(emptyTile.pos)) adjacentTiles.Add(tile);

            if (adjacentTiles.Count > 0)
                SwapTiles(adjacentTiles[Random.Range(0, adjacentTiles.Count)]);
        }
    }

    void CheckWin()
    {
        for (int i = 0; i < tiles.Count - 1; i++)
        {
            if (tiles[i].isEmpty) return;
            if (tiles[i].text.text != (i + 1).ToString()) return;
        }

        Debug.Log("You Win!");

        // บันทึกว่าผ่านแล้ว
        PlayerPrefs.SetInt("PuzzleCompleted", 1);
        PlayerPrefs.Save();

        // กลับ Level3 อัตโนมัติ
        SceneManager.LoadScene("Level3");
    }
}