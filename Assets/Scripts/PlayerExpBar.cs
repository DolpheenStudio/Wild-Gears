using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpBar : MonoBehaviour
{
    private Slider expBar;
    private Player player;
    private bool isFillActive;
    public GameObject expBarFill;
    private int playerLevel;
    
    void Start()
    {
        expBar = GetComponent<Slider>();
        player = FindObjectOfType<Player>();
        expBar.maxValue = player.playerMaxExp;
        playerLevel = player.playerLevel;
    }

    void Update()
    {
        if(player.playerExp > 0)
        {
            if (!isFillActive) expBarFill.SetActive(true);
            expBar.value = player.playerExp;
        }
        else
        {
            isFillActive = false;
            expBarFill.SetActive(false);
        }
        if(playerLevel != player.playerLevel)
        {
            expBar.maxValue = player.playerMaxExp;
        }
    }
}
