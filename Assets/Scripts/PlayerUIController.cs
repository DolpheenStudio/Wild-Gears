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
    public GameObject pauseButton;
    public GameObject[] weaponSlots = new GameObject[3];

    private Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if(Time.timeScale == 0)
        {
            movementJoystick.SetActive(false);
            playerExpBar.SetActive(false);
            playerHealthBar.SetActive(false);
            timer.SetActive(false);
            pauseButton.SetActive(false);

            pauseBG.SetActive(true);
            upgradeScreen.SetActive(true);
        }
        else
        {
            movementJoystick.SetActive(true);
            playerExpBar.SetActive(true);
            playerHealthBar.SetActive(true);
            timer.SetActive(true);
            pauseButton.SetActive(true);

            pauseBG.SetActive(false);
            upgradeScreen.SetActive(false);
        }
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
