using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    private TMP_Text text;
    private Player player;
    private int oldLevel;

    void Start()
    {
        player = FindObjectOfType<Player>();
        text = GetComponent<TMP_Text>();

        oldLevel = player.playerLevel;
        text.SetText("Level " + player.playerLevel.ToString());
    }

    void Update()
    {
        if (oldLevel != player.playerLevel)
        {
            text.SetText("Level " + player.playerLevel.ToString());
            oldLevel = player.playerLevel;
        }
    }
}
