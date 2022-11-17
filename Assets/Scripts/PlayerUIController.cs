using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public GameObject movementJoystick;
    public GameObject pauseBG;
    public GameObject upgradeScreen;
    public GameObject playerExpBar;
    public GameObject playerHealthBar;
    public GameObject timer;
    public GameObject playerUpgradePointsCounter;
    public GameObject playerLevelCounter;
    public GameObject pauseButton;
    public GameObject weaponPickScreen;
    public GameObject[] weaponSlots = new GameObject[3];

    public Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        DisableUpgradeScreen();
        DisablePlayerUI();
    }

    void Update()
    {

    }

    public void EnableUpgradeScreen()
    {
        pauseBG.SetActive(true);
        upgradeScreen.SetActive(true);
    }

    public void EnablePlayerUI()
    {
        movementJoystick.SetActive(true);
        playerExpBar.SetActive(true);
        playerHealthBar.SetActive(true);
        timer.SetActive(true);
        playerUpgradePointsCounter.SetActive(true);
        playerLevelCounter.SetActive(true);
        pauseButton.SetActive(true);
    }

    public void DisablePlayerUI()
    {
        movementJoystick.SetActive(false);
        playerExpBar.SetActive(false);
        playerHealthBar.SetActive(false);
        timer.SetActive(false);
        playerUpgradePointsCounter.SetActive(false);
        playerLevelCounter.SetActive(false);
        pauseButton.SetActive(false);
    }

    public void DisableUpgradeScreen()
    {
        pauseBG.SetActive(false);
        upgradeScreen.SetActive(false);
    }

    public void EnablePickWeaponScreen()
    {
        movementJoystick.SetActive(false);
        playerExpBar.SetActive(false);
        playerHealthBar.SetActive(false);
        timer.SetActive(false);
        playerUpgradePointsCounter.SetActive(false);
        playerLevelCounter.SetActive(false);
        pauseButton.SetActive(false);

        weaponPickScreen.SetActive(true);
    }

    public void DisablePickWeaponScreen()
    {
        movementJoystick.SetActive(true);
        playerExpBar.SetActive(true);
        playerHealthBar.SetActive(true);
        timer.SetActive(true);
        playerUpgradePointsCounter.SetActive(true);
        playerLevelCounter.SetActive(true);
        pauseButton.SetActive(true);

        weaponPickScreen.SetActive(false);
    }

    public GameObject FreeWeaponSlot()
    {
        if (player.playerWeaponAmount < 3)
        {
            return weaponSlots[player.playerWeaponAmount];
        }
        else return null;
    }
}
