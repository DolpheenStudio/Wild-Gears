using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUpgrade : MonoBehaviour
{
    private Player player;
    private PlayerUIController playerUIController;
    private int playerHealthUpgrade = 0;
    private int playerSpeedUpgrade = 0;
    private int playerPickupRadiusUpgrade = 0;

    public TMP_Text healthUpgrade;
    public TMP_Text speedUpgrade;
    public TMP_Text pickupRadiusUpgrade;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerUIController = FindObjectOfType<PlayerUIController>();
    }

    public void AddPlayerHealth()
    {
        if(player.playerUpgradePoints >= 1)
        {
            player.playerHealth += 10;
            player.playerMaxHealth += 10;
            playerHealthUpgrade++;
            healthUpgrade.text = playerHealthUpgrade.ToString();
            player.playerUpgradePoints --;
        }
    }

    public void AddPlayerSpeed()
    {
        if (player.playerUpgradePoints >= 1)
        {
            player.playerSpeed += 0.2f;
            playerSpeedUpgrade++;
            speedUpgrade.text = playerSpeedUpgrade.ToString();
            player.playerUpgradePoints --;
        }
    }

    public void AddPlayerPickupRadius()
    {
        if (player.playerUpgradePoints >= 1)
        {
            player.playerPickupRange += 0.2f;
            playerPickupRadiusUpgrade++;
            pickupRadiusUpgrade.text = playerPickupRadiusUpgrade.ToString();
            player.playerUpgradePoints --;
        }
    }

    public void ExitUpgrade()
    {
        Time.timeScale = 1;
        playerUIController.DisableUpgradeScreen();
        playerUIController.EnablePlayerUI();
    }
}
