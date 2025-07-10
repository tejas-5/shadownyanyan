using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Puzzle15Manager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform gridParent;

    private List<Tile> tiles = new List<Tile>();
    private const int size = 4; // 3x3 grid for 8-puzzle

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
        Debug.Log($"Swapping tile {clickedTile.text.text} at pos {clickedTile.pos}");

        Tile emptyTile = GetEmptyTile();

        if (!clickedTile.IsAdjacent(emptyTile.pos))
        {
            Debug.Log("Tiles not adjacent. Swap canceled.");
            return;
        }

        int clickedNumber = int.Parse(clickedTile.text.text);

        clickedTile.SetEmpty();
        emptyTile.SetNumber(clickedNumber);

        emptyTile = clickedTile;

        Vector2Int tempPos = clickedTile.pos;
        clickedTile.pos = emptyTile.pos;
        emptyTile.pos = tempPos;

        Debug.Log($"Swapped. New positions: clickedTile {clickedTile.pos}, emptyTile {emptyTile.pos}");

        CheckWin();
    }

    void ShuffleTiles()
    {
        for (int i = 0; i < 100; i++)
        {
            Tile emptyTile = GetEmptyTile();
            List<Tile> adjacentTiles = new List<Tile>();

            // Find adjacent tiles to empty
            foreach (var tile in tiles)
            {
                if (tile.IsAdjacent(emptyTile.pos))
                {
                    adjacentTiles.Add(tile);
                }
            }

            if (adjacentTiles.Count > 0)
            {
                Tile tileToMove = adjacentTiles[Random.Range(0, adjacentTiles.Count)];
                SwapTiles(tileToMove);
            }
        }
    }

    void CheckWin()
    {
        for (int i = 0; i < tiles.Count - 1; i++) // last tile is empty
        {
            if (tiles[i].isEmpty) return;

            int expected = i + 1;
            if (tiles[i].text.text != expected.ToString())
                return;
        }

        // ถ้าชนะ
        Debug.Log("You Win!");

        // ✅ บันทึกว่าผ่านแล้ว
        PlayerPrefs.SetInt("PuzzleCompleted", 1);
        PlayerPrefs.Save();

        // ✅ กลับไป Main Scene
        SceneManager.LoadScene("Level3");
    }
}
