using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOut : MonoBehaviour
{
    private Player player;
    private Camera mainCamera;
    private GenerateFloorTile tileGenerator;
    void Start()
    {
        player = FindObjectOfType<Player>();
        tileGenerator = FindObjectOfType<GenerateFloorTile>();
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if(player.playerLevel == 10 && mainCamera.orthographicSize != 8)
        {
            mainCamera.orthographicSize = 8;
            tileGenerator.visibleTiles = 4;
        }

        if (player.playerLevel == 20 && mainCamera.orthographicSize != 9)
        {
            mainCamera.orthographicSize = 9;
            tileGenerator.visibleTiles = 5;
        }
    }
}
