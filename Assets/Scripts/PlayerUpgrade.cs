using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    private Player player;
    private int playerHealthUpgrade = 0;
    private int playerSpeedUpgrade = 0;
    private int playerPickupRadiusUpgrade = 0;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void AddPlayerHealth()
    {
        if(player.playerUpgradePoints > playerHealthUpgrade)
        {
            player.playerHealth += 10;
            player.playerMaxHealth += 10;
            playerHealthUpgrade++;
            player.playerUpgradePoints -= playerHealthUpgrade;
            Time.timeScale = 1;
        }
    }

    public void AddPlayerSpeed()
    {
        if (player.playerUpgradePoints > playerSpeedUpgrade)
        {
            player.playerSpeed += 0.2f;
            playerSpeedUpgrade++;
            player.playerUpgradePoints -= playerSpeedUpgrade;
            Time.timeScale = 1;
        }
    }

    public void AddPlayerPickupRadius()
    {
        if (player.playerUpgradePoints > playerPickupRadiusUpgrade)
        {
            player.playerPickupRange += 0.2f;
            playerPickupRadiusUpgrade++;
            player.playerUpgradePoints -= playerPickupRadiusUpgrade;
            Time.timeScale = 1;
        }
    }

    public void SkipUpgrade()
    {
        Time.timeScale = 1;
    }
}
