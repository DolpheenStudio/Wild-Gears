using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Player player;
    public Slider playerHealthBar;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        playerHealthBar.value = player.playerHealth;
        playerHealthBar.maxValue = player.playerMaxHealth;
    }
}
