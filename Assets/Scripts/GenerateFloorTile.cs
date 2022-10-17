using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloorTile : MonoBehaviour
{
    private int tileSize = 5;
    
    [Range(1, 3)]
    public int visibleTiles = 1;

    private int currentPlayerX;
    private int currentPlayerY;

    private Dictionary<Vector2, GameObject> tilesDictionary = new Dictionary<Vector2, GameObject>();

    public Transform player;
    public GameObject[] tilePrefab;
    public Transform parent;
    void Start()
    {
        UpdateCurrentPlayerTile();
        UpdateVisibleTiles();
    }

    void Update()
    {
        UpdateCurrentPlayerTile();
        UpdateVisibleTiles();
    }

    void UpdateCurrentPlayerTile()
    {
        currentPlayerX = Mathf.RoundToInt(player.position.x / tileSize);
        currentPlayerY = Mathf.RoundToInt(player.position.y / tileSize);
    }

    void UpdateVisibleTiles()
    {
        List<Vector2> visibleTilesCoords = new List<Vector2>();

        for(int x = -visibleTiles + currentPlayerX; x < visibleTiles + currentPlayerX + 1; x++)
        {
            for (int y = -visibleTiles + currentPlayerY; y < visibleTiles + currentPlayerY + 1; y++)
            {
                Vector2 tileCoords = new Vector2(x, y);
                visibleTilesCoords.Add(tileCoords);
                if(tilesDictionary.ContainsKey(tileCoords))
                {
                    tilesDictionary[tileCoords].SetActive(true);
                }
                else
                {
                    GenerateTile(tileCoords);
                }
            }
        }
    }

    void GenerateTile(Vector2 tileCoords)
    {
        int randomTile = Random.Range(0, 3);
        GameObject tempTile = Instantiate(tilePrefab[randomTile], new Vector3(tileCoords.x * tileSize, tileCoords.y * tileSize, 0f), Quaternion.Euler(0f, 0f, 0f));
        tempTile.transform.parent = parent;
        tilesDictionary.Add(tileCoords, tempTile);
    }
}
