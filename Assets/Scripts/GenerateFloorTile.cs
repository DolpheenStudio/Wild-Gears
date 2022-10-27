using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloorTile : MonoBehaviour
{
    private int tileSize = 5;
    private float halfTileSize;
    
    [Range(1, 3)]
    public int visibleTiles = 1;

    private int currentPlayerX;
    private int currentPlayerY;

    private Dictionary<Vector2, GameObject> tilesDictionary = new Dictionary<Vector2, GameObject>();

    public Transform player;
    public GameObject[] tilePrefab;
    public Transform parent;
    public GameObject[] enviormentObjectsArray;
    void Start()
    {
        UpdateCurrentPlayerTile();
        UpdateVisibleTiles();

        halfTileSize = tileSize / 2f;
        Debug.Log(halfTileSize);
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
        int randomTile = Random.Range(0, 14);
        float randomTileRotation = Random.Range(0, 4) * 90f;
        GameObject tempTile;
        if (randomTile <= 7)
        {
            tempTile = Instantiate(tilePrefab[0], new Vector3(tileCoords.x * tileSize, tileCoords.y * tileSize, 0f), Quaternion.Euler(0f, 0f, randomTileRotation));
        }
        else
        {
            tempTile = Instantiate(tilePrefab[randomTile - 7], new Vector3(tileCoords.x * tileSize, tileCoords.y * tileSize, 0f), Quaternion.Euler(0f, 0f, randomTileRotation));
        }
        tempTile.transform.parent = parent;
        int spawnEnviorment = Random.Range(0, enviormentObjectsArray.Length * 2);
        if(spawnEnviorment < enviormentObjectsArray.Length)
        {
            GameObject cactusGameObject = Instantiate(enviormentObjectsArray[spawnEnviorment], Vector3.zero, transform.rotation);
            cactusGameObject.transform.SetParent(tempTile.transform);
            cactusGameObject.transform.localPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), 0f);
        }
        tilesDictionary.Add(tileCoords, tempTile);
    }
}
