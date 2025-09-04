using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle15Manager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform gridParent;   // Panel ที่มี Grid Layout Group
    private List<Tile> tiles = new List<Tile>();
    private const int size = 3;

    void Start()
    {
        GenerateTiles();
        ShuffleTilesProperly();
    }

    void GenerateTiles()
    {
        int count = 1;
        for (int i = 0; i < size * size; i++)
        {
            GameObject tileObj = Instantiate(tilePrefab, gridParent);
            Tile tile = tileObj.GetComponent<Tile>();
            if (tile == null)
            {
                Debug.LogError("Tile component missing on prefab!");
                continue;
            }

            int number = (i == size * size - 1) ? 0 : count++;
            Vector2Int pos = new Vector2Int(i % size, i / size);

            tile.Init(this, number, pos);
            tiles.Add(tile);
        }

        Debug.Log($"Generated {tiles.Count} tiles.");
    }

    void ShuffleTilesProperly()
    {
        List<int> numbers;
        do
        {
            numbers = new List<int>();
            for (int i = 1; i < size * size; i++)
                numbers.Add(i);
            numbers.Add(0); // empty tile

            // Fisher-Yates shuffle
            for (int i = numbers.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
        } while (!IsSolvable(numbers, size));

        // apply numbers ลง tile
        for (int i = 0; i < tiles.Count; i++)
        {
            int number = numbers[i];
            if (number == 0)
                tiles[i].SetEmpty();
            else
                tiles[i].SetNumber(number);

            tiles[i].pos = new Vector2Int(i % size, i / size);
        }
    }

    bool IsSolvable(List<int> numbers, int size)
    {
        int inversions = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[i] > 0 && numbers[j] > 0 && numbers[i] > numbers[j])
                    inversions++;
            }
        }

        if (size % 2 == 1)
        {
            // grid ขนาดคี่ → solvable ถ้า inversions เป็นเลขคู่
            return inversions % 2 == 0;
        }
        else
        {
            int emptyRowFromBottom = size - (numbers.IndexOf(0) / size);
            // grid ขนาดคู่ → solvable ถ้า (inversions + row ของ empty จากล่าง) เป็นเลขคู่
            return (inversions + emptyRowFromBottom) % 2 == 0;
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

        int clickedNumber = clickedTile.number;

        clickedTile.SetEmpty();
        emptyTile.SetNumber(clickedNumber);


        CheckWin();
    }

    void CheckWin()
    {
        for (int i = 0; i < tiles.Count - 1; i++)
        {
            if (tiles[i] == null) return;
            if (tiles[i].isEmpty) return;
            if (tiles[i].number != i + 1) return;
        }

        Debug.Log("You Win!");
        if (GameManager.Instance != null)
            GameManager.Instance.puzzleCompleted = true;

        SceneManager.LoadScene("Level3");
    }
}